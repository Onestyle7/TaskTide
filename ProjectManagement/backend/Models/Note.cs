using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.backend.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Range(1,5)]
        public int Priority { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
