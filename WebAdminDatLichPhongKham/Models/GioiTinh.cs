using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAdminDatLichPhongKham.Models
{
    public enum Gender
    {
        [Description("Nam")]
        Male,

        [Description("Nữ")]
        Female,

        [Description("Khác")]
        Other
    }

}
