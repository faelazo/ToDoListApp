using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Entity;

namespace ToDoListApp.Controllers
{
    [Route("api/[controller]")]
    public class ToDoListController : Controller
    {
        private readonly Service.IToDoListService tdlService;

        public ToDoListController(Service.IToDoListService tdlService)
        {
            this.tdlService = tdlService;
        }

        [HttpGet("[action]")]
        public IActionResult Tasks(int startUserID)
        {
            try { 
                return Ok(this.tdlService.getUserTasks(startUserID));
            }
            catch (System.Exception e)
            {
                return BadRequest("Internal Error");
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

                return Ok(newItem);
            }
            catch (System.Exception e)
            {
                return BadRequest("Internal Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeStateTask([FromBody] int id)
        {
            try { 
                int userID = await this.tdlService.changeStateTask(id);

                if (userID == 0)
                    return BadRequest("Task Not Found");

                this.tdlService.save();

                return Ok(this.tdlService.getUserTasks(userID));
            }
            catch (System.Exception e)
            {
                return BadRequest("Internal Error");
            }
        }
    }
}
