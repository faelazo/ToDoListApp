using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;
using ToDoListApp.Service;
using ToDoListApp.Entity;

namespace ToDoListApp.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private Service.ToDoListService tdlService;

        public SampleDataController()
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
        public List<ItemList> ChangeStateTask(int taskID)
        {
            return this.tdlService.changeStateTask(taskID);
        }

    }
}
