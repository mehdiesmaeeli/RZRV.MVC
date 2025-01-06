using System.ComponentModel.DataAnnotations;

namespace RZRV.APP.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

}
