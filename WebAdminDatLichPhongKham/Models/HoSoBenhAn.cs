using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models
{
    public class HoSoBenhAn
    {
        public int Id { get; set; }

        [Display(Name = "Mã phiếu đặt lịch")]
        public int PhieuDatLichId { get; set; }

        public PhieuDatLich PhieuDatLich { get; set; }

        [Display(Name = "Chẩn đoán")]
        public string ChanDoan { get; set; }

        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        [Display(Name = "Tổng tiền")]
        public double TongTien { get; set; }

        public ICollection<ChiTietHoSoBenhAn> ChiTietHoSoBenhAns { get; set; }
    }
}
