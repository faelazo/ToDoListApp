
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Entity;

namespace ToDoListApp.Controllers
{
    [Route("api/[controller]")]
    public class ToDoListController : Controller
    {
        private Service.ToDoListService tdlService;

        public ToDoListController()
        {
            tdlService = new Service.ToDoListService();
        }

        [HttpGet("[action]")]
        public IEnumerable<ItemList> Tasks(int startUserID)
        {
            return this.tdlService.getUserTasks(startUserID);
        }


        [HttpGet("[action]")]
        public ItemList AddTask(int startUserID, string task)
        {
            return this.tdlService.addTask(startUserID, task);
        }

        [HttpGet("[action]")]
        public IEnumerable<ItemList> ChangeStateTask(int taskID)
        {
            return this.tdlService.changeStateTask(taskID);
        }

    }
}
