namespace Assignment.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int Role { get; set; } 

        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
