using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListApp.Entity;

namespace ToDoListApp.Service
{
    public interface IToDoListService
    {
        IEnumerable<ItemList> getUserTasks(int startUserID);

        Task<ItemList> addTask(int startUserID, string task);

        void save();

        Task<int> changeStateTask(int taskID);
    }
}
