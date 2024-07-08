namespace ProjectManagement.backend.Models
{
    public class TaskItem
    {
        public int Id { get; set;}
        public string Title { get; set; }
        public string Description { get; set; } // ToDo, InProgress, Closed
        public string Status { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
