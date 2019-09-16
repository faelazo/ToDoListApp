using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Repository;
using ToDoListApp.Entity;

namespace ToDoListApp.Service
{
    public class ToDoListService
    {
        private ToDoListRepository tdlRepository;

        public ToDoListService()
        {
            this.tdlRepository = new ToDoListRepository();
        }

        public IEnumerable<ItemList> getUserTasks(int startUserID)
        {
            return this.tdlRepository.getUserTasks(startUserID);
        }

        public ItemList addTask(int startUserID, string task)
        {
            return this.tdlRepository.addTask(startUserID, task);
        }

        public List<ItemList> changeStateTask(int taskID)
        {
            return this.tdlRepository.changeStateTask(taskID);
        }
    }
}
