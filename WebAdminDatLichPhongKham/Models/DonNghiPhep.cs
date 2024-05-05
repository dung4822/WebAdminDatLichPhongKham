using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models
{
    public class DonNghiPhep
    {
        public int Id { get; set; }
        [DisplayName("Ngày đăng ký")]
        public DateTime NgayDK { get; set; }
        [DisplayName("Ngày nghỉ")]
        public DateTime NgayNghi { get; set; }
        [DisplayName("Lý Do")]
        [MaxLength(255)]
        public string LyDo { get; set; }
        public int NhanvienId { get; set; }
        public NhanVien NhanVien { get; set; }

        public ICollection<CaNghiPhep> CaNghiPheps { get; set; }
     }
}
