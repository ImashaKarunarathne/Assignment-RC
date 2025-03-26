namespace Assignment.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Status { get; set; }

        public DateTime DueDate { get; set; }

        public int UserId { get; set; }

        //public User User { get; set; }
    }
}
