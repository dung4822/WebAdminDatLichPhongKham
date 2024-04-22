using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models
{
    public class Khoa
    {
        [Key]
        public int idKhoa { get; set; }
        [Required(ErrorMessage = "Tên khoa không được để trống")]
        [MaxLength(225, ErrorMessage = "Tên khoa không được vượt quá 225 ký tự")]
        public string TenKhoa { get; set; }
        public string? Mota { get; set; }
    }
}
