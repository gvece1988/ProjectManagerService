using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManager.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using ProjectManager.Business;
using ProjectManager.Entities;

namespace ProjectManager.API.Tests
{
    public class TaskControllerTest
    {
        private readonly Mock<ITaskBL> taskBL;
        private readonly TaskController taskController;

        public TaskControllerTest()
        {
            taskBL = new Mock<ITaskBL>();
            taskController = new TaskController(taskBL.Object);
        }

        [Fact]
        public void GetAll()
        {
            // Arrange
            taskBL.Setup(m => m.GetTasks()).Returns(GetTestTasks());
            // Act
            var result = taskController.Get();
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetById()
        {
            // Arrange
            taskBL.Setup(m => m.GetTaskById(1)).Returns(GetTestTasks().First());
            // Act
            var result = taskController.GetById(1);
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetTasksByProjectId()
        {
            // Arrange
            taskBL.Setup(m => m.GetTasksByProjectId(1)).Returns(GetTestTasks());
            // Act
            var result = taskController.GetByProjectId(1);
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetParentTasks()
        {
            // Arrange
            taskBL.Setup(m => m.GetParentTasks()).Returns(GetTestTasks());
            // Act
            var result = taskController.GetParentTasks();
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Post()
        {
            // Arrange
            var task = GetTestTasks().First();
            taskBL.Setup(m => m.AddTask(task));
            // Act
            var result = taskController.Post(task) as OkResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Put()
        {
            // Arrange
            var task = GetTestTasks().First();
            taskBL.Setup(m => m.UpdateTask(task));
            // Act
            var result = taskController.Put(task) as OkResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            taskBL.Setup(m => m.EndTask(It.IsAny<int>()));
            // Act
            var result = taskController.Delete(1) as OkResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_ErrorResponse()
        {
            // Arrange
            taskBL.Setup(m => m.EndTask(It.IsAny<int>()));
            // Act
            var result = taskController.Delete(0) as BadRequestResult;
            // Assert
            Assert.NotNull(result);
        }

        private IEnumerable<Task> GetTestTasks()
        {
            return new[]
            {
                new Task{ Title="Test task", Priority=10, StartDate = DateTime.Now.Date,  EndDate = DateTime.Now.AddDays(10).Date },
                new Task{ Title="Test task1", Priority=15, StartDate = DateTime.Now.Date,  EndDate = DateTime.Now.AddDays(5).Date }
            };
        }
    }
}
