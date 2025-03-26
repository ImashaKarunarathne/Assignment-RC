namespace Assignment.DTOs.Common
{
    public class FilterCriteria
    {
        public string FilterBy { get; set; } = string.Empty;

        public int FilterValue { get; set; }

        public DateTime dueDate { get; set; }
    }
}
