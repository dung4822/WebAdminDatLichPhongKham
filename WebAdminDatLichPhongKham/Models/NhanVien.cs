using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminDatLichPhongKham.Models
{
    public class NhanVien
    {
        [Key]
        public int idNhanVien { get; set; }
        [Required]
        public string HoTen { get; set; }
        public string? GioiTinh { get; set; }
        public string? SDT { get; set; }

        public DateTime? Ngaysinh { get; set; }

        public string? Hinhanh { get; set; }
        public int? idKhoa { get; set; }
        public int? idChucVu { get; set; }
        [ForeignKey("idChucVu")]
        public ChucVu chucVu { get; set; }
        [ForeignKey("idKhoa")]
        public Khoa khoa { get; set; }
    }
}
