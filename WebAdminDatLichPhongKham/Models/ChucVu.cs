using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models
{
    public class ChucVu
    {
        [Key]
        public int idChucVu { get; set; }
        [Required,MaxLength(50)]
        public string Tenchucvu { get; set; }
        public string? Mota { get; set; }
    }
}
