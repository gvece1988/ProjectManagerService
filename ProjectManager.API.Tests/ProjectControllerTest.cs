using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManager.API.Controllers;
using ProjectManager.Business;
using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProjectManager.API.Tests
{
    public class ProjectControllerTest
    {
        private readonly Mock<IProjectBL> projectBL;
        private readonly ProjectController projectController;

        public ProjectControllerTest()
        {
            projectBL = new Mock<IProjectBL>();
            projectController = new ProjectController(projectBL.Object);
        }

        [Fact]
        public void GetAll()
        {
            // Arrange
            projectBL.Setup(m => m.GetProjects()).Returns(GetTestProjects());
            // Act
            var result = projectController.Get();
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Search()
        {
            // Arrange
            projectBL.Setup(m => m.SearchProjects("Test")).Returns(GetTestProjects());
            // Act
            var result = projectController.Search("Test");
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Post()
        {
            // Arrange
            var project = GetTestProjects().First();
            projectBL.Setup(m => m.AddProject(project));
            // Act
            var result = projectController.Post(project) as OkResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Put()
        {
            // Arrange
            var project = GetTestProjects().First();
            projectBL.Setup(m => m.UpdateProject(project));
            // Act
            var result = projectController.Put(project) as OkResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            projectBL.Setup(m => m.DeleteProject(It.IsAny<int>()));
            // Act
            var result = projectController.Delete(1) as OkResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_ErrorResponse()
        {
            // Arrange
            projectBL.Setup(m => m.DeleteProject(It.IsAny<int>()));
            // Act
            var result = projectController.Delete(0) as BadRequestResult;
            // Assert
            Assert.NotNull(result);
        }

        private IEnumerable<Project> GetTestProjects()
        {
            return new[]
            {
                new Project{ Title="Test project", Priority=10, StartDate = DateTime.Now.Date,  EndDate = DateTime.Now.AddDays(10).Date },
                new Project{ Title="Test project1", Priority=15, StartDate = DateTime.Now.Date,  EndDate = DateTime.Now.AddDays(5).Date }
            };
        }
    }
}
