import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/AddNewTask';
import './styles.css';

class AddNewTask extends Component {
    
    render() {
        return (
            <div>
                <h1>New Task</h1>
                <form>
                    <div className="form-group">
                        <label htmlFor="task">Type new task:</label>
                        <textarea className="form-control" rows="3" onChange={(e) => this.props.add(e.target.value)}></textarea>
                    </div>
                    <button className="btn btn-danger" onClick={this.props.requestAddNewTask}>Save</button>
                </form>
            </div>
        );
    }
}

export default connect(
    state => state.newTask,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(AddNewTask);
