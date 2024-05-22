using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models
{
    public class Thuoc
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên thuốc.")]
        [StringLength(100, ErrorMessage = "Tên thuốc không được vượt quá 100 kí tự.")]
        public string TenThuoc { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá tiền.")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá tiền không hợp lệ.")]
        public double GiaTien { get; set; }
    }
}
