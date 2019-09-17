
using System.Collections.Generic;
using System.Threading.Tasks;
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


        [HttpPost("[action]")]
        public async Task<IActionResult> AddTask([FromBody] TaskModified taskMod)
        {
            ItemList newItem = await this.tdlService.addTask(taskMod.userID, taskMod.task);

            if (newItem == null)
                BadRequest("Task Not Found");

            this.tdlService.save();

            return Ok(value: newItem);
        }

        public class TaskModified
        {
            public int userID { get; set; }
            public string task { get; set; }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeStateTask([FromBody] int id)
        {
            int userID = await this.tdlService.changeStateTask(id);

            if (userID == 0)
                BadRequest("Task Not Found");

            this.tdlService.save();

            return Ok(value: this.tdlService.getUserTasks(userID));
        }
    }
}
