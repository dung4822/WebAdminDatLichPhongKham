using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models
{
    public class CaKham
    {
        public int Id { get; set; }
        [DisplayName("Tên Ca")]
        [MaxLength(100)]
        public string TenCa { get; set; }
        [Required]
        [DisplayName("Thời gian bắt đầu")]
        public TimeSpan TGBatDau { get; set; }
        [Required]
        [DisplayName("Thời gian kết thúc")]
        public TimeSpan TGKetThuc { get; set; }
        [Required]
        [DisplayName("Hệ số lương")]
        public float HeSoLuong { get; set; }

        public ICollection<CaNghiPhep> CaNghiPheps { get; set; }
        public ICollection<PhieuDatLich> PhieuDatLichs { get; set; }
    }
}
