using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminDatLichPhongKham.Models
{
    public class NhanVien
    {
        [Key]
        public int idNhanVien { get; set; }
      
        [Required]
        [DisplayName("Họ và tên")]
        public string HoTen { get; set; }
        [DisplayName("Giới tính")]
        public string? GioiTinh { get; set; }
        [DisplayName("Số điện thoại")]
        public string? SDT { get; set; }
        [DisplayName("Ngày sinh")]
        public DateTime? Ngaysinh { get; set; }
        [DisplayName("Hình ảnh")]
        public string? Hinhanh { get; set; }
        [DisplayName("Khoa")]
        public int? idKhoa { get; set; }
        [DisplayName("Chức vụ")]
        public int? idChucVu { get; set; }
        [ForeignKey("idChucVu")]
        public ChucVu chucVu { get; set; }
        [ForeignKey("idKhoa")]
        public Khoa khoa { get; set; }
        public ICollection<DonNghiPhep> DonNghiPheps { get; set; }
        public ICollection<PhieuDatLich> PhieuDatLichs { get; set; }
    }
}
