namespace Assignment.DTOs.Task
{
    public class ViewTaskDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Status { get; set; }

        public DateTime DueDate { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;
    }
}
