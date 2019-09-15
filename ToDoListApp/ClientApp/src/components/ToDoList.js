import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/ToDoList';
import './styles.css';

class ToDoList extends Component {
    componentDidMount() {
        // This method is called when the component is first added to the document
        this.ensureDataFetched();
    }

    componentDidUpdate() {
        // This method is called when the route parameters change
        this.ensureDataFetched();
    }

    ensureDataFetched() {
        const startUserID = parseInt(this.props.match.params.startUserID, 10) || 21;
        this.props.requestToDoList(startUserID);
    }

    render() {
        return (
            <div>
                <h1>ToDo List</h1>
                <form className="formRadios">
                    <label><input type="radio" name="filter" onChange={this.props.all} value="All" checked={this.props.filter==0} />All</label>
                    <label><input type="radio" name="filter" onChange={this.props.completed} value="Completed" checked={this.props.filter == 1}/>Completed</label>
                    <label><input type="radio" name="filter" onChange={this.props.pending} value="Pending" checked={this.props.filter == 2}/>Pending</label>
                </form>
                {renderToDoListTable(this.props)}
            </div>
        );
    }
}

function renderToDoListTable(props) {
    return (
        <table className='table table-striped'>
            <thead>
                <tr>
                    <th>Description</th>
                    <th>State</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {props.tasks.map(task => {
                        if ((props.filter === 2)&&(task.state === "Pending")){
                            return (<tr key={task.taskID}>
                                        <td>{task.description}</td>
                                        <td>{task.state}</td>
                                        <td><img src={process.env.PUBLIC_URL + '/changeState24.png'} onClick={() => props.changeStateTask(task.taskID)} /></td>
                                    </tr>);
                        }else if ((props.filter === 1)&&(task.state === "Completed")){
                            return (<tr key={task.taskID}>
                                        <td>{task.description}</td>
                                        <td>{task.state}</td>
                                        <td><img src={process.env.PUBLIC_URL + '/changeState24.png'} onClick={() => props.changeStateTask(task.taskID)} /></td>
                                    </tr>);
                        }else if (props.filter === 0){
                            return (<tr key={task.taskID}>
                                        <td>{task.description}</td>
                                        <td>{task.state}</td>
                                        <td><img src={process.env.PUBLIC_URL + '/changeState24.png'} onClick={() => props.changeStateTask(task.taskID)} /></td>
                                    </tr>);
                        }
                    }
                )}
            </tbody>
        </table>
    );
}

export default connect(
    state => state.tasks,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(ToDoList);
