using System.Collections.Generic;
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
