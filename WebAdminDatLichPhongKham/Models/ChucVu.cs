using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models
{
    public class ChucVu
    {
        [Key]
        public int id { get; set; }
        [Required,MaxLength(50)]
        public string Tenchucvu { get; set; }
        public string? Mota { get; set; }
    }
}
