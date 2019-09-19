using NUnit.Framework;
using System.Threading.Tasks;

namespace ToDoListNUnitTest
{
    [TestFixture]
    class ToDoListRepository
    {
        [Test]
        public void loadTasks()
        {
            ToDoListApp.Repository.ToDoListRepository repository = new ToDoListApp.Repository.ToDoListRepository();
            repository.loadTasks();

            Assert.IsNotNull(repository.getUserTasks(21));
        }

        [Test]
        public async Task AddTask()
        {
            ToDoListApp.Repository.ToDoListRepository repository = new ToDoListApp.Repository.ToDoListRepository();
            repository.loadTasks();

            ToDoListApp.Repository.ItemRepository item = await repository.addTask(100, "New task generate by ToDoListTest");

            Assert.IsNotNull(item);
        }
        [Test]
        public void GetUserTasksNotExist()
        {
            ToDoListApp.Repository.ToDoListRepository repository = new ToDoListApp.Repository.ToDoListRepository();

            Assert.IsEmpty(repository.getUserTasks(0));
        }

        [Test]
        public async Task GetUserTasksExist()
        {
            ToDoListApp.Repository.ToDoListRepository repository = new ToDoListApp.Repository.ToDoListRepository();

            await repository.addTask(100, "New task by NUnit Test");
            repository.save();

            Assert.IsNotEmpty(repository.getUserTasks(100));
        }

        [Test]
        public async Task ChangeState()
        {
            ToDoListApp.Repository.ToDoListRepository repository = new ToDoListApp.Repository.ToDoListRepository();

            ToDoListApp.Repository.ItemRepository item = await repository.addTask(101, "New task by NUnit Test");
            repository.save();

            int userID = await repository.changeStateTask(item.id);

            Assert.IsTrue(userID > 0);
        }
    }
}