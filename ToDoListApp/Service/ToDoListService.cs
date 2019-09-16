using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Repository;
using ToDoListApp.Entity;

namespace ToDoListApp.Service
{
    public class ToDoListService: IToDoListService
    {
        private IToDoListRepository tdlRepository;

        public ToDoListService()
        {
            this.tdlRepository = new ToDoListRepository();
        }

        public IEnumerable<ItemList> getUserTasks(int userID)
        {
            List<ItemRepository> items = this.tdlRepository.getUserTasks(userID);

            List<ItemList> tasksList = new List<ItemList>();

            foreach(ItemRepository iter in items)
            {
                tasksList.Add(new ItemList(iter.id, iter.description, iter.state, iter.userID));
            }

            return tasksList;
        }

        public ItemList addTask(int startUserID, string task)
        {
            ItemRepository itemRep = this.tdlRepository.addTask(startUserID, task);

            return new ItemList(itemRep.id, itemRep.description, itemRep.state, itemRep.userID);
        }

        public IEnumerable<ItemList> changeStateTask(int taskID)
        {
            List<ItemRepository> listRep = this.tdlRepository.changeStateTask(taskID);

            List<ItemList> items = new List<ItemList>();

            foreach(ItemRepository itemRep in listRep)
            {
                items.Add(new ItemList(itemRep.id, itemRep.description, itemRep.state, itemRep.userID));
            }

            return items;
        }
    }
}
