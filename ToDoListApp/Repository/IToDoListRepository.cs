﻿using System.Collections.Generic;

namespace ToDoListApp.Repository
{
    interface IToDoListRepository
    {
        void loadTasks();
        void loadUserTasks(int userID);

        List<ItemRepository> getUserTasks(int startUserID);

        ItemRepository addTask(int startUserID, string task);

        void save();

        int changeStateTask(int taskID);
    }
}
