using Assignment.DTOs.Common;
using Assignment.DTOs.Task;

namespace Assignment.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<ViewTaskDto>> GetTasksByUserId(int userId);

        Task<ViewTaskDto> CreateTask(CreateTaskDto createTaskDto);

        Task<ViewTaskDto> DeleteTask(int id);

        Task<List<ViewTaskDto>> FilterTask(int id, FilterCriteria filterCriteria);
    }
}
