using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebAdminDatLichPhongKham.Models;

namespace WebAdminDatLichPhongKham.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{

    public string MaNhanVien { get; set; }
    public NhanVien nhanVien { get; set; }
}

