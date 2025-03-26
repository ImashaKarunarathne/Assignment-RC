using System.ComponentModel;

namespace Assignment.Enums
{
    public class TaskStatus
    {
        public enum TaksStatus
        {
            [Description("New")]
            New = 1,
            [Description("Pending")]
            Pending = 2,
            [Description("Completed")]
            Completed = 3,
            [Description("Rejected")]
            Rejected = 4,
        }
    }
}
