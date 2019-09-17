
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
            try { 
                return this.tdlService.getUserTasks(startUserID);
            }
            catch (System.Exception e)
            {
                return null;
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddTask([FromBody] TaskModified taskMod)
        {
            try
            {
                ItemList newItem = await this.tdlService.addTask(taskMod.userID, taskMod.task);

                if (newItem == null)
                    return BadRequest("Task Not Found");

                this.tdlService.save();

                return Ok(value: newItem);
            }
            catch (System.Exception e)
            {
                return BadRequest("Internal Error");
            }
        }

        public class TaskModified
        {
            public int userID { get; set; }
            public string task { get; set; }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeStateTask([FromBody] int id)
        {
            try { 
                int userID = await this.tdlService.changeStateTask(id);

                if (userID == 0)
                    return BadRequest("Task Not Found");

                this.tdlService.save();

                return Ok(value: this.tdlService.getUserTasks(userID));
            }
            catch (System.Exception e)
            {
                return BadRequest("Internal Error");
            }
        }
    }
}
