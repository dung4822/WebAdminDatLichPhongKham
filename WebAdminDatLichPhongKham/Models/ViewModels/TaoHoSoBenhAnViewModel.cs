namespace WebAdminDatLichPhongKham.Models.ViewModels
{
    public class TaoHoSoBenhAnViewModel
    {
        public int PhieuDatLichId { get; set; }
        public int BenhNhanId { get; set; }
        public string BenhNhanName { get; set; }
        public string ChanDoan { get; set; }
        public string GhiChu { get; set; }
        public List<ChiTietThuocViewModel> ChiTietThuoc { get; set; }
    }
}
