const requestToDoListType = 'REQUEST_TODO_LIST';
const receiveToDoListType = 'RECEIVE_TODO_LIST';
const changeStateTaskType = 'CHANGE_STATE_TASK';
const initialState = { tasks: [], filter: 0};

const allFilterType = 'ALL_FILTER';
const completedFilterType = 'COMPLETED_FILTER';
const pendingFilterType = 'PENDING_FILTER';


export const actionCreators = {
    requestToDoList: startUserID => async (dispatch, getState) => {
        if (startUserID === getState().tasks.startUserID) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
        }

        dispatch({ type: requestToDoListType, startUserID });

        const url = `api/ToDoList/Tasks?startUserID=${startUserID}`;
        const response = await fetch(url);
        const tasks = await response.json();

        dispatch({ type: receiveToDoListType, startUserID, tasks });
    },
    changeStateTask: (taskID) => async (dispatch, getState) => {

        const url = `api/ToDoList/ChangeStateTask?taskID=${taskID}`;
        const response = await fetch(url);
        const tasks = await response.json();

        dispatch({ type: changeStateTaskType, tasks });
    },
    all: () => ({ type: allFilterType }),
    completed: () => ({ type: completedFilterType }),
    pending: () => ({ type: pendingFilterType })
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestToDoListType) {
        return {
            ...state,
            startUserID: action.startUserID
        };
    }

    if (action.type === receiveToDoListType) {
        return {
            ...state,
            startUserID: action.startUserID,
            tasks: action.tasks
        };
    }

    if (action.type === changeStateTaskType) {
        return {
            ...state,
            tasks: action.tasks
        };
    }

    if (action.type === allFilterType) {
        return { ...state, filter: 0 };
    }

    if (action.type === completedFilterType) {
        return { ...state, filter: 1 };
    }

    if (action.type === pendingFilterType) {
        return { ...state, filter: 2 };
    }

    return state;
};