const requestAddNewTaskType = 'REQUEST_ADD_NEW_TASK';
const receiveAddNewTaskType = 'RECEIVE_ADD_NEW_TASK';
const addNewTaskType = 'ADD_NEW_TASK';

const initialState = { newTask: '' };

export const actionCreators = {
    requestAddNewTask: () => async (dispatch, getState) => {

        var startUserID = getState().tasks.startUserID;
        var newTask = getState().newTask.newTask;

        if (startUserID <= 0) return
        if (newTask === "") return

        dispatch({ type: requestAddNewTaskType, startUserID });
        
        const url = `api/ToDoList/AddTask?startUserID=${startUserID}&task=${newTask}`;
        const response = await fetch(url);
        const respTask = await response.json();

        dispatch({ type: receiveAddNewTaskType, startUserID, respTask });
    },
    add: (newTask) => {
        return ({ type: addNewTaskType, newTask })
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestAddNewTaskType) {
        return {
            ...state,
            startUserID: action.startUserID
        };
    }

    if (action.type === receiveAddNewTaskType) {
        return {
            ...state,
            startUserID: action.startUserID,
            newTask: action.respTask.description
        };
    }

    if (action.type === addNewTaskType) {
        return { ...state, newTask: action.newTask };
    }

    return state;
};
