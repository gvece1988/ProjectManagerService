using ProjectManager.Entities;
using System;
using System.Linq;
using Xunit;

namespace ProjectManager.Business.Tests
{
    public class UserBLTest : IClassFixture<DbContextFixture>
    {
        private readonly UserBL userBL;
        public DbContextFixture _dbfixture;
        public UserBLTest(DbContextFixture dbFixture)
        {
            _dbfixture = dbFixture;
            userBL = new UserBL(_dbfixture.dbContext);
        }

        [Fact]
        public void GetAll()
        {
            var users = userBL.GetUsers();

            Assert.NotNull(users);
        }

        [Fact]
        public void SearchUsers()
        {
            var users = userBL.SearchUsers("Test user");

            Assert.NotNull(users);
        }

        [Fact]
        public void Add()
        {
            var id = userBL.AddUser(new User
            {
                FirstName = "Test user2",
                EmployeeId = "1234"
            });

            Assert.True(id > 0);
        }

        [Fact]
        public void Update()
        {
            var id = userBL.AddUser(new User
            {
                FirstName = "Test user2",
                EmployeeId = "12345"
            });

            var newName = "Test user update";
            var user = userBL.GetUsers().First(m => m.Id == id);
            user.FirstName = newName;

            user = userBL.UpdateUser(user);

            Assert.True(user.FirstName == newName);
        }

        [Fact]
        public void Delete()
        {
            userBL.DeleteUser(1);

            var user = userBL.GetUsers().FirstOrDefault(m => m.Id == 1);

            Assert.Null(user);
        }
    }
}
