using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoListApp.Repository
{
    interface IToDoListRepository
    {
        void loadTasks();
        void loadUserTasks(int userID);

        List<ItemRepository> getUserTasks(int startUserID);

        Task<ItemRepository> addTask(int startUserID, string task);

        void save();

        Task<int> changeStateTask(int taskID);
    }
}
