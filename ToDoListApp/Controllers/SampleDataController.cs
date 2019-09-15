using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;

namespace ToDoListApp.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private const string pasthJSON = @"./Data/tasks.json";
        private static string[] States = new[]
        {
            "Completed", "Pending"
        };

        [HttpGet("[action]")]
        public IEnumerable<Task> Tasks(int startUserID)
        {
            return this.getTasks(startUserID);
        }


        [HttpGet("[action]")]
        public Task AddTask(int startUserID, string task)
        {
            List<Task> tasks = JsonConvert.DeserializeObject<List<Task>>(System.IO.File.ReadAllText(pasthJSON));

            int id = 1;

            if (tasks.Count > 0) id = tasks.Last().TaskID + 1;

            Task newTask = new Task
            {
                TaskID = id,
                Description = task,
                State = States[1],
                UserID = startUserID
            };

            tasks.Add(newTask);

            System.IO.File.WriteAllText(pasthJSON, JsonConvert.SerializeObject(tasks));

            return newTask;
        }

        [HttpGet("[action]")]
        public List<Task> ChangeStateTask(int taskID)
        {
            List<Task> tasks = JsonConvert.DeserializeObject<List<Task>>(System.IO.File.ReadAllText(pasthJSON));

            int index = 0;
            bool found = false;
            int userID = 0;

            while (!found && index < tasks.Count)
            {
                if (tasks[index].TaskID == taskID)
                {
                    if (tasks[index].State == States[0]) tasks[index].State = States[1];
                    else tasks[index].State = States[0];
                    found = true;
                    userID = tasks[index].UserID;
                }

                index++;
            }

            System.IO.File.WriteAllText(pasthJSON, JsonConvert.SerializeObject(tasks));

            return this.getTasks(userID);
        }

        private List<Task> getTasks(int userID)
        {
            List<Task> tasksFromFile = JsonConvert.DeserializeObject<List<Task>>(System.IO.File.ReadAllText(pasthJSON));

            List<Task> tasks = new List<Task>();

            foreach(Task task in tasksFromFile)
            {
                if (task.UserID == userID)
                {
                    tasks.Add(task);
                }
            }

            return tasks;
        }

        public class Task
        {
            public int TaskID { get; set; }
            public string Description { get; set; }
            public string State { get; set; }
            public int UserID { get; set; }
        };

    }
}
