namespace WebAdminDatLichPhongKham.Models
{
    public class CaNghiPhep
    {
        public int DonNghiPhepId{ get; set; }
        public int CaKhamId { get; set; }
        public DonNghiPhep DonNghiPhep { get; set; }
        public CaKham CaKham { get; set; }

    }
}
