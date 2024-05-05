using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebAdminDatLichPhongKham.Areas.Identity.Data;
using WebAdminDatLichPhongKham.Models;

namespace WebAdminDatLichPhongKham.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
        builder.Entity<CaNghiPhep>()
              .HasKey(c => new { c.DonNghiPhepId, c.CaKhamId });
    }
    public DbSet<Khoa> Khoas { get; set; }
    public DbSet<ChucVu> ChucVus {  get; set; } 
    public DbSet<NhanVien> NhanViens { get; set; }
    public DbSet<CaKham> CaKhams{ get; set; }
    public DbSet<CaNghiPhep> CaNghiPheps { get; set; }
    public DbSet<DonNghiPhep> DonNghiPheps { get; set; }
    public DbSet<BenhNhan> BenhNhans { get; set; }
    public DbSet<PhieuDatLich> PhieuDatLichs { get; set; }

}
