using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ToDoListApp.Repository
{
    public class ToDoListRepository: IToDoListRepository
    {
        private List<ItemRepository> tasks;

        public void loadTasks()
        {
            this.tasks = JsonConvert.DeserializeObject<List<ItemRepository>>(System.IO.File.ReadAllText(Commons.Commons.pasthJSON));
        }

        public void loadUserTasks(int userID)
        {
            List<ItemRepository> tasksFromFile = JsonConvert.DeserializeObject<List<ItemRepository>>(System.IO.File.ReadAllText(Commons.Commons.pasthJSON));

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

            if (this.tasks == null)
            {
                this.loadTasks();
            }

            if (this.tasks.Count > 0)
            {
                id = this.tasks.Last().id + 1;
            }

            ItemRepository newTask = new ItemRepository
            {
                id = id,
                description = task,
                state = Commons.Commons.States.Pending.ToString(),
                userID = user
            };

            this.tasks.Add(newTask);

            return newTask;
        }

        public void save()
        {
            if (this.tasks != null)
            {
                List<ItemRepository> tasksFile = JsonConvert.DeserializeObject<List<ItemRepository>>(System.IO.File.ReadAllText(Commons.Commons.pasthJSON));

                foreach(ItemRepository item in this.tasks)
                {
                    if (tasksFile.Contains(item))
                    {
                        tasksFile.Remove(item);
                    }
                    tasksFile.Add(item);
                }

                System.IO.File.WriteAllText(Commons.Commons.pasthJSON, JsonConvert.SerializeObject(tasksFile));
            }
        }

        public int changeStateTask(int taskID)
        {
            int index = 0;
            bool found = false;
            int userID = 0;

            if (this.tasks == null)
            {
                this.loadTasks();
            }

            while (!found && index < this.tasks.Count)
            {
                if (this.tasks[index].id == taskID)
                {
                    if (this.tasks[index].state.Equals(Commons.Commons.States.Completed.ToString()))
                    {
                        this.tasks[index].state = Commons.Commons.States.Pending.ToString();
                    }
                    else
                    {
                        this.tasks[index].state = Commons.Commons.States.Completed.ToString();
                    }
                    found = true;
                    userID = this.tasks[index].userID;
                }

                index++;
            }

            return userID;
        }
    }
}
