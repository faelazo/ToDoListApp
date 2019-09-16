using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDoListApp.Repository;
using ToDoListApp.Entity;

namespace ToDoListApp.Repository
{
    public class ToDoListRepository
    {
        private const string pasthJSON = @"./Data/tasks.json";
        private static string[] States = new[]
        {
            "Completed", "Pending"
        };

        public IEnumerable<ItemList> getUserTasks(int startUserID)
        {
            return this.getTasks(startUserID);
        }

        public ItemList addTask(int startUserID, string task)
        {
            List<ItemList> tasks = JsonConvert.DeserializeObject<List<ItemList>>(System.IO.File.ReadAllText(pasthJSON));

            int id = 1;

            if (tasks.Count > 0) id = tasks.Last().TaskID + 1;

            ItemList newTask = new ItemList
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

        public List<ItemList> changeStateTask(int taskID)
        {
            List<ItemList> tasks = JsonConvert.DeserializeObject<List<ItemList>>(System.IO.File.ReadAllText(pasthJSON));

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

        private List<ItemList> getTasks(int userID)
        {
            List<ItemList> tasksFromFile = JsonConvert.DeserializeObject<List<ItemList>>(System.IO.File.ReadAllText(pasthJSON));

            List<ItemList> tasks = new List<ItemList>();

            foreach (ItemList task in tasksFromFile)
            {
                if (task.UserID == userID)
                {
                    tasks.Add(task);
                }
            }

            return tasks;
        }

    }
}
