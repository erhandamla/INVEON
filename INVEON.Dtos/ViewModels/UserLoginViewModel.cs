using System.ComponentModel.DataAnnotations;

namespace INVEON.Dtos.ViewModels
{
    public class UserLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Display(Name = "Parola")]
        public string Password { get; set; }
    }
}
