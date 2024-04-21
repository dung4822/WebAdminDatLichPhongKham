using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models
{
    public class Khoa
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Tên khoa không được để trống")]
        [MaxLength(225, ErrorMessage = "Tên khoa không được vượt quá 225 ký tự")]
        public string TenKhoa { get; set; }
        public string? Mota { get; set; }
    }
}
