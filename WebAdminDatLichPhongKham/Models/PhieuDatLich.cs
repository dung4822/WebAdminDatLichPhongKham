using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdminDatLichPhongKham.Models
{
    public class PhieuDatLich
    {
        public int Id { get; set; }

        [Display(Name = "Ngày đặt")]
        public DateTime NgayDat { get; set; }

        [Display(Name = "Ngày khám")]
        public DateTime NgayKham { get; set; }

        [Display(Name = "Mã bệnh nhân")]
        public int BenhNhanId { get; set; }

        public BenhNhan BenhNhan { get; set; }

        [Display(Name = "Ca khám")]
        public int CaKhamId { get; set; }

        public CaKham CaKham { get; set; }
        [ForeignKey("NhanVien")]
        [Display(Name = "Mã nhân viên")]
        public int idNhanVien { get; set; }

        public NhanVien NhanVien { get; set; }
        public HoSoBenhAn HoSoBenhAn { get; set; }
    }
}
