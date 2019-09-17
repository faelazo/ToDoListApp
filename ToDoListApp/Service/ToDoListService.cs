using System.Collections.Generic;
using ToDoListApp.Repository;
using ToDoListApp.Entity;
using System.Threading.Tasks;

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
            List<ItemRepository> listRep = this.tdlRepository.getUserTasks(userID);

            return this.getList(listRep);
        }

        public async Task<ItemList> addTask(int startUserID, string task)
        {
            ItemRepository itemRep = await this.tdlRepository.addTask(startUserID, task);

            return new ItemList(itemRep.id, itemRep.description, itemRep.state, itemRep.userID);
        }

        public void save()
        {
            this.tdlRepository.save();
        }

        public async Task<int> changeStateTask(int taskID)
        {
            return await this.tdlRepository.changeStateTask(taskID);
        }

        private List<ItemList> getList(List<ItemRepository> listRep)
        {
            List<ItemList> items = new List<ItemList>();

            foreach (ItemRepository itemRep in listRep)
            {
                items.Add(new ItemList(itemRep.id, itemRep.description, itemRep.state, itemRep.userID));
            }

            return items;
        }
    }
}
