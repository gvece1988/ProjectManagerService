using ProjectManager.Entities;
using System;
using Xunit;

namespace ProjectManager.Business.Tests
{
    public class TaskBLTest : IClassFixture<DbContextFixture>
    {
        private readonly TaskBL taskBL;
        public DbContextFixture _dbfixture;
        public TaskBLTest(DbContextFixture dbFixture)
        {
            _dbfixture = dbFixture;
            taskBL = new TaskBL(_dbfixture.dbContext);
        }

        [Fact]
        public void GetAll()
        {
            var tasks = taskBL.GetTasks();

            Assert.NotNull(tasks);
        }

        [Fact]
        public void GetParentTasks()
        {
            var taskLookups = taskBL.GetParentTasks();

            Assert.NotNull(taskLookups);
        }

        [Fact]
        public void GetTaskByProjectId()
        {
            var taskLookups = taskBL.GetTasksByProjectId(1);

            Assert.NotNull(taskLookups);
        }

        [Fact]
        public void GetById()
        {
            var task = taskBL.GetTaskById(1);

            Assert.NotNull(task);
        }

        [Fact]
        public void Add()
        {
            var id = taskBL.AddTask(new Task
            {
                Title = "Test task2",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                ProjectId = 1
            });

            Assert.True(id > 0);
        }

        [Fact]
        public void Update()
        {
            var newTitle = "Test task1";

            var task = GetTestTask();
            task.Title = newTitle;

            taskBL.UpdateTask(task);

            task = taskBL.GetTaskById(1);

            Assert.True(task.Title == newTitle);
        }

        [Fact]
        public void End()
        {
            taskBL.EndTask(1);

            var task = taskBL.GetTaskById(1);

            Assert.True(task.IsCompleted);
        }

        private Task GetTestTask()
        {
            return new Task
            {
                Id = 1,
                Title = "Test task",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
        }
    }
}
