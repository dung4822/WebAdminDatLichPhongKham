using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models
{
    public class BenhNhan
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên.")]
        [StringLength(50, ErrorMessage = "Tên không được vượt quá 50 kí tự.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số CMND.")]
        [RegularExpression("^[0-9]{9,12}$", ErrorMessage = "Số CMND không hợp lệ.")]
        public string CMND { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [RegularExpression("^0[0-9]{9,10}$", ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string PhoneNumber { get; set; }
        public ICollection<PhieuDatLich> PhieuDatLichs { get; set; }
    }
}
