using System.ComponentModel.DataAnnotations;

namespace amfTaskManager.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Username is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
