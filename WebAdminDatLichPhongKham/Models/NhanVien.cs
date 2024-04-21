using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models
{
    public class NhanVien
    {
        [Key]
        public int id { get; set; }
        [Required] 
        public string MaNhanVien { get; set; }
        [Required]
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string? SDT { get; set; }

        public DateTime? Ngaysinh { get; set; }

        public string? Hinhanh { get; set; }
        public int Khoaid { get; set; }
        public int ChucVuid { get; set; }
        public ChucVu chucVu { get; set; }
        public Khoa khoa { get; set; }
    }
}
