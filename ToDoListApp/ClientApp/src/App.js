import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import ToDoList from './components/ToDoList';
import AddNewTask from './components/AddNewTask';

export default () => (
  <Layout>
        <Route exact path='/' component={ToDoList} />
        <Route path='/to-do-list/:startUserID?' component={ToDoList} />
        <Route path='/add-new-task/:startUserID?' component={AddNewTask} />
  </Layout>
);
