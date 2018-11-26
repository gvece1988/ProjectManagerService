using ProjectManager.Business;
using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using ProjectManager.Entities;
using ProjectManager.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ProjectManager.API.Tests
{
    public class UserControllerTest
    {
        private readonly Mock<IUserBL> userBL;
        private readonly UserController userController;

        public UserControllerTest()
        {
            userBL = new Mock<IUserBL>();
            userController = new UserController(userBL.Object);
        }

        [Fact]
        public void GetAll()
        {
            // Arrange
            userBL.Setup(m => m.GetUsers()).Returns(GetTestUsers());            
            // Act
            var result = userController.Get();            
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Search()
        {
            // Arrange
            userBL.Setup(m => m.SearchUsers("Test")).Returns(GetTestUsers());
            // Act
            var result = userController.Search("Test");
            // Assert
            Assert.NotNull(result);
        }
        
        [Fact]
        public void Post()
        {
            // Arrange
            var user = GetTestUsers().First();
            userBL.Setup(m => m.AddUser(user));
            // Act
            var result = userController.Post(user) as OkResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Put()
        {
            // Arrange
            var user = GetTestUsers().First();
            userBL.Setup(m => m.UpdateUser(user));
            // Act
            var result = userController.Put(user) as OkResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            userBL.Setup(m => m.DeleteUser(It.IsAny<int>()));
            // Act
            var result = userController.Delete(1) as OkResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_ErrorResponse()
        {
            // Arrange
            userBL.Setup(m => m.DeleteUser(It.IsAny<int>()));
            // Act
            var result = userController.Delete(0) as BadRequestResult;
            // Assert
            Assert.NotNull(result);
        }

        private IEnumerable<User> GetTestUsers()
        {
            return new[]
            {
                new User{ EmployeeId="1234", FirstName="Test user", LastName="Test"},
                new User{ EmployeeId="55888", FirstName="Test user1", LastName="Test1"}
            };
        }
    }
}
