namespace Assignment.DTOs.Task
{
    public class CreateTaskDto
    {
        public string Name { get; set; } = string.Empty;

        public int Status { get; set; }

        public DateTime DueDate { get; set; }

        public int UserId { get; set; }
    }
}
