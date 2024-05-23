using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int idNhanVien { get; set; }

        public List<string> Roles { get; set; }

        public bool IsEdit { get; set; } = false;
    }
}
