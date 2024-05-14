using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models.ViewModels
{
    public class BenhNhanDatLichViewModels
    {

        public BenhNhan BenhNhan { get; set; }
        public int KhoaId { get; set; }
        public DateTime NgayKham { get; set; }
        public int CaKhamId { get; set; }
        public int BacSiId { get; set; }


    }
}
