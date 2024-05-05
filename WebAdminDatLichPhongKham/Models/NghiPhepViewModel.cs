using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using WebAdminDatLichPhongKham.Areas.Identity.Data;

namespace WebAdminDatLichPhongKham.Models
{

    public class NghiPhepViewModel
    {
        [Required(ErrorMessage = "Vui lòng chọn ngày nghỉ.")]
        [Display(Name = "Ngày nghỉ")]
        public DateTime NgayNghi { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lý do.")]
        [Display(Name = "Lý do")]
        public string LyDo { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn một ca khám.")]
        [Display(Name = "Ca khám")]
        public int SelectedCaKhamId { get; set; }

        public List<CaKham> CaKhamList { get; set; }
    }
}
