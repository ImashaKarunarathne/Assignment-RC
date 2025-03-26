using Assignment.Data;
using Assignment.DTOs.Task;
using Assignment.Models;
using Assignment.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Assignment.Test
{
    public class TaskRepositoryTests
    {
        private ApplicationDBContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique DB for each test
                .Options;

            return new ApplicationDBContext(options);
        }

        [Fact]
        public async Task GetTasksByUserId_ShouldReturnTasks_WhenUserHasTasks()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            context.Tasks.AddRange(
                new TaskItem { Id = 1, Name = "Task1", Status = 1, DueDate = DateTime.Now, UserId = 1 },
                new TaskItem { Id = 2, Name = "Task2", Status = 2, DueDate = DateTime.Now, UserId = 2 }
            );
            await context.SaveChangesAsync();

            var repository = new TaksRepository(context);

            // Act
            var tasks = await repository.GetTasksByUserId(1);

            // Assert
            Assert.Single(tasks);
            Assert.Equal("Task1", tasks.First().Name);
        }

        [Fact]
        public async Task CreateTask_ShouldAddTask_AndReturnViewTaskDto()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new TaksRepository(context);

            var newTask = new CreateTaskDto
            {
                Name = "New Task",
                Status = 1,
                DueDate = DateTime.Now,
                UserId = 1
            };

            // Act
            var result = await repository.CreateTask(newTask);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New Task", result.Name);
            Assert.Equal(2, result.Status);
            Assert.Single(context.Tasks); // Ensure task was added to DB
        }

        [Fact]
        public async Task DeleteTask_ShouldRemoveTask_WhenTaskExists()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            context.Tasks.Add(new TaskItem { Id = 1, Name = "Task1", Status = 2, DueDate = DateTime.Now, UserId = 1 });
            await context.SaveChangesAsync();

            var repository = new TaksRepository(context);

            // Act
            var deletedTask = await repository.DeleteTask(1);
            var taskInDb = await context.Tasks.FindAsync(1);

            // Assert
            Assert.NotNull(deletedTask);
            Assert.Equal("Task1", deletedTask.Name);
            Assert.Null(taskInDb); // Task should be removed
        }

        [Fact]
        public async Task DeleteTask_ShouldReturnNull_WhenTaskDoesNotExist()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new TaksRepository(context);

            // Act
            var result = await repository.DeleteTask(999); // Non-existent ID

            // Assert
            Assert.Null(result);
        }
    }
}
