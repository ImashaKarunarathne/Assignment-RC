using Assignment.Data;
using Assignment.DTOs.Task;
using Assignment.Interfaces;
using Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Repository
{
    public class TaksRepository : ITaskRepository
    {
        private readonly ApplicationDBContext _context;

        public async Task<List<ViewTaskDto>> GetTasksByUserId(int userId)
        {
            var tasks = await _context.Tasks
                         .Where(t => t.UserId == userId)
                         .Select(t => new ViewTaskDto
                         {
                             Id = t.Id,
                             Name = t.Name,
                             Status = t.Status,
                             DueDate = t.DueDate,
                             UserId = t.UserId,
                         })
                         .ToListAsync();

            return tasks;
        }

        public async Task<ViewTaskDto> CreateTask(CreateTaskDto createTaskDto)
        {
            var task = new TaskItem
            {
                Name = createTaskDto.Name,
                Status = createTaskDto.Status,
                DueDate = createTaskDto.DueDate,
                UserId = createTaskDto.UserId,
            };

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return new ViewTaskDto
            {
                Id = task.Id,
                Name = task.Name,
                Status = task.Status,
                DueDate = task.DueDate,
                UserId = task.UserId,
            };
        }

        public async Task<ViewTaskDto> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return null;
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return new ViewTaskDto
            {
                Id = task.Id,
                Name = task.Name,
                Status = task.Status,
                DueDate = task.DueDate,
                UserId = task.UserId,
            };
        }
    }
}
