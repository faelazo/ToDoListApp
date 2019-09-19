using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListApp.Repository;
using ToDoListApp.Service;

namespace ToDoListNUnitTest
{
    [TestFixture]
    class ToDoListService
    {
        [Test]
        public void LoadTasks()
        {
            var mock = new Mock<IToDoListRepository>();

            mock.Setup(m => m.loadTasks());

            var tdlService = new ToDoListApp.Service.ToDoListService(mock.Object);

            Assert.IsNotNull(mock.Object);
        }

        [Test]
        public async Task AddTask()
        {
            var mock = new Mock<IToDoListRepository>();

            mock.Setup(m => m.loadTasks());

            var tdlService = new ToDoListApp.Service.ToDoListService(mock.Object);

            Assert.IsNotNull(tdlService.addTask(100, "New task by Mock"));
        }
        [Test]
        public void GetUserTasksNotExist()
        {
            var mock = new Mock<IToDoListRepository>();

            mock.Setup(m => m.getUserTasks(0)).Returns(() => new List<ItemRepository> { });

            var emptyList = mock.Object.getUserTasks(0);

            Assert.AreEqual(new List<ItemRepository>(), emptyList);
        }

        [Test]
        public async Task GetUserTasksExist()
        {
            var mock = new Mock<IToDoListRepository>();

            var item = new ItemRepository
            {
                id = 1,
                description = "Test Task",
                state = ToDoListApp.Commons.Commons.States.Pending.ToString(),
                userID = 200
            };

            mock.Setup(m => m.getUserTasks(200)).Returns(() => new List<ItemRepository> { item });

            mock.Object.addTask(200, "Test Task");
            var notEmptyList = mock.Object.getUserTasks(200);

            Assert.AreEqual(new List<ItemRepository> { item }, notEmptyList);
        }

        [Test]
        public async Task ChangeState()
        {
            var mock = new Mock<IToDoListRepository>();

            mock.Setup(m => m.changeStateTask(It.IsAny<int>())).Returns(Task.FromResult(100));

            Assert.AreEqual(mock.Object.changeStateTask(1).Result, 100);
        }
    }
}
