﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApp.Repository
{
    interface IToDoListRepository
    {
        void loadTasks();
        void loadUserTasks(int userID);

        List<ItemRepository> getUserTasks(int startUserID);

        ItemRepository addTask(int startUserID, string task);

        List<ItemRepository> changeStateTask(int taskID);
    }
}
