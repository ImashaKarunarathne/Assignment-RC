using Assignment.Data;
using Assignment.DTOs.Common;
using Assignment.DTOs.Task;
using Assignment.Interfaces;
using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using static Assignment.Enums.TaskStatus;

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

        public async Task<List<ViewTaskDto>> FilterTask(int id, FilterCriteria filterCriteria)
        {
            var tasks = await _context.Tasks
                         .Where(t => t.UserId == id)
                         .Select(t => new ViewTaskDto
                         {
                             Id = t.Id,
                             Name = t.Name,
                             Status = t.Status,
                             DueDate = t.DueDate,
                             UserId = t.UserId,
                         })
                         .ToListAsync();

            if (filterCriteria.dueDate !=null && filterCriteria.FilterBy != null)
            {
                var tasksByDueDate = tasks.Where(t => t.DueDate == filterCriteria.dueDate).ToList();
                if (filterCriteria.FilterBy == "Status")
                {
                    tasks = tasks.Where(t => t.Status == filterCriteria.FilterValue).ToList();
                }
                
            }

            return tasks;
        }   
    }
}
