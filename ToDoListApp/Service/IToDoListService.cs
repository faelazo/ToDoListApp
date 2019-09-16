using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Entity;

namespace ToDoListApp.Service
{
    interface IToDoListService
    {
        IEnumerable<ItemList> getUserTasks(int startUserID);

        ItemList addTask(int startUserID, string task);

        IEnumerable<ItemList> changeStateTask(int taskID);
    }
}
