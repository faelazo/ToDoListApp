using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListApp.Entity;

namespace ToDoListApp.Service
{
    interface IToDoListService
    {
        IEnumerable<ItemList> getUserTasks(int startUserID);

        Task<ItemList> addTask(int startUserID, string task);

        Task<int> changeStateTask(int taskID);
    }
}
