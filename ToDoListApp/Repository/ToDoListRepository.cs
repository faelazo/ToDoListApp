using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToDoListApp.Repository
{
    public class ToDoListRepository: IToDoListRepository
    {
        private const string pasthJSON = @"./Data/tasks.json";
        private static string[] States = new[]
        {
            "Completed", "Pending"
        };

        private List<ItemRepository> tasks;

        public void loadTasks()
        {
            this.tasks = JsonConvert.DeserializeObject<List<ItemRepository>>(System.IO.File.ReadAllText(pasthJSON));
        }

        public void loadUserTasks(int userID)
        {
            List<ItemRepository> tasksFromFile = JsonConvert.DeserializeObject<List<ItemRepository>>(System.IO.File.ReadAllText(pasthJSON));

            this.tasks = new List<ItemRepository>();

            foreach (ItemRepository task in tasksFromFile)
            {
                if (task.userID == userID)
                {
                    this.tasks.Add(task);
                }
            }
        }

        public List<ItemRepository> getUserTasks(int userID)
        {
            this.loadUserTasks(userID);

            List<ItemRepository> userTasks = new List<ItemRepository>();

            foreach (ItemRepository task in this.tasks)
            {
                if (task.userID == userID)
                {
                    userTasks.Add(task);
                }
            }

            return userTasks;
        }

        public ItemRepository addTask(int user, string task)
        {
            int id = 1;

            if (this.tasks == null) this.loadUserTasks(user);

            if (this.tasks.Count > 0) id = this.tasks.Last().id + 1;

            ItemRepository newTask = new ItemRepository
            {
                id = id,
                description = task,
                state = States[1],
                userID = user
            };

            this.tasks.Add(newTask);

            System.IO.File.WriteAllText(pasthJSON, JsonConvert.SerializeObject(this.tasks));

            return newTask;
        }

        public List<ItemRepository> changeStateTask(int taskID)
        {
            int index = 0;
            bool found = false;
            int userID = 0;

            if (this.tasks == null) this.loadTasks();

            while (!found && index < this.tasks.Count)
            {
                if (this.tasks[index].id == taskID)
                {
                    if (this.tasks[index].state == States[0]) this.tasks[index].state = States[1];
                    else this.tasks[index].state = States[0];
                    found = true;
                    userID = this.tasks[index].userID;
                }

                index++;
            }

            System.IO.File.WriteAllText(pasthJSON, JsonConvert.SerializeObject(this.tasks));

            return this.getUserTasks(userID);
        }
    }
}
