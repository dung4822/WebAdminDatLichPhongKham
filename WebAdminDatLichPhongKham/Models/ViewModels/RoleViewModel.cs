using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
