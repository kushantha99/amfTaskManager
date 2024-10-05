using System.ComponentModel.DataAnnotations;

namespace amfTaskManager.Models
{
    public class UserTask
    {
        [Key]
        public int UserTaskID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
