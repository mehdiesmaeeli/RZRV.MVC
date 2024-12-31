using System.ComponentModel.DataAnnotations;

namespace RZRV.APP.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Phone { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }

    }

}
