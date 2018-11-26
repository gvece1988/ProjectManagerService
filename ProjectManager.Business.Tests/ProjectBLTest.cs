using ProjectManager.Entities;
using System;
using System.Linq;
using Xunit;

namespace ProjectManager.Business.Tests
{
    public class ProjectBLTest : IClassFixture<DbContextFixture>
    {
        private readonly ProjectBL projectBL;
        public DbContextFixture _dbfixture;
        public ProjectBLTest(DbContextFixture dbFixture)
        {
            _dbfixture = dbFixture;
            projectBL = new ProjectBL(_dbfixture.dbContext);
        }

        [Fact]
        public void GetAll()
        {
            var projects = projectBL.GetProjects();

            Assert.NotNull(projects);
        }

        [Fact]
        public void SearchProjects()
        {
            var projects = projectBL.SearchProjects("Test project");

            Assert.NotNull(projects);
        }

        [Fact]
        public void Add()
        {
            var id = projectBL.AddProject(new Project
            {
                Title = "Test project2",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            });

            Assert.True(id > 0);
        }

        [Fact]
        public void Update()
        {
            var project = projectBL.SearchProjects("Test project").First();
            project.Priority = 10;

            project = projectBL.UpdateProject(project);

            Assert.True(project.Priority == 10);
        }

        [Fact]
        public void Delete()
        {
            var id = projectBL.AddProject(new Project
            {
                Title = "Test project",
                ManagerId = 1
            });

            projectBL.DeleteProject(id);

            var project = projectBL.GetProjects().FirstOrDefault(m => m.Id == id);

            Assert.Null(project);
        }
    }
}
