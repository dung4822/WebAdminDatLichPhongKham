using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models
{
    public class ChiTietHoSoBenhAn
    {
        public int Id { get; set; }

        [Display(Name = "Mã hồ sơ bệnh án")]
        public int HoSoBenhAnId { get; set; }

        public HoSoBenhAn HoSoBenhAn { get; set; }

        [Display(Name = "Mã thuốc")]
        public int ThuocId { get; set; }

        public Thuoc Thuoc { get; set; }

        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }
    }
}
