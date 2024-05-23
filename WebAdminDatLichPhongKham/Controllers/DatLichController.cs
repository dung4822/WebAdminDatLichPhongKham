using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using WebAdminDatLichPhongKham.Areas.Identity.Data;
using WebAdminDatLichPhongKham.Models;
using WebAdminDatLichPhongKham.Models.ViewModels;

namespace WebAdminDatLichPhongKham.Controllers
{
    public class DatLichController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DatLichController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.KhoaList = new SelectList(_context.Khoas.ToList(), "idKhoa", "TenKhoa");
            ViewBag.CaKhamList = new SelectList(_context.CaKhams.ToList(), "Id", "TenCa");
            return View(new BenhNhanDatLichViewModels());
        }
        [HttpPost]
        public IActionResult GetDoctors([FromBody] BenhNhanDatLichViewModels viewModel)
        {
            // Chuyển đổi ngày khám sang ngày mà không bao gồm phần thời gian
            var ngayKhamWithoutTime = viewModel.NgayKham.Date;

            // Lọc danh sách nhân viên dựa trên khoa, ngày khám, và ca khám đã chọn
            var doctors = _context.NhanViens
                         .Where(nv => nv.idKhoa == viewModel.KhoaId &&
                                      !nv.DonNghiPheps.Any(dnp => dnp.NgayNghi.Date == ngayKhamWithoutTime &&
                                                                   dnp.CaNghiPheps.Any(cnp => cnp.CaKhamId == viewModel.CaKhamId)))
                         .ToList();


            // Trả về danh sách nhân viên dưới dạng JSON
            return Json(doctors);
        }
        [HttpPost]
        public IActionResult DatLich(BenhNhanDatLichViewModels viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Tạo một bệnh nhân mới từ dữ liệu trong viewModel
                var benhNhan = new BenhNhan
                {
                    Name = viewModel.BenhNhan.Name,
                    CMND = viewModel.BenhNhan.CMND,
                    Gender = viewModel.BenhNhan.Gender,
                    Email = viewModel.BenhNhan.Email,
                    PhoneNumber = viewModel.BenhNhan.PhoneNumber
                };

                // Thêm bệnh nhân mới vào cơ sở dữ liệu
                _context.BenhNhans.Add(benhNhan);
                _context.SaveChanges();

                // Tạo một phiếu đặt lịch mới từ dữ liệu trong viewModel
                var phieuDatLich = new PhieuDatLich
                {
                    NgayDat = DateTime.Now, // Ngày đặt là ngày hiện tại
                    NgayKham = viewModel.NgayKham,
                    BenhNhanId = benhNhan.Id, // Sử dụng ID của bệnh nhân vừa tạo
                    CaKhamId = viewModel.CaKhamId,
                    idNhanVien = viewModel.BacSiId
                };

                // Thêm phiếu đặt lịch vào cơ sở dữ liệu
                _context.PhieuDatLichs.Add(phieuDatLich);
                _context.SaveChanges();

/*
                // Tạo nội dung email
                string subject = "Xác nhận đặt lịch khám bệnh";
                string body = $"Xin chào {viewModel.BenhNhan.Name},\n\n";
                body += $"Bạn đã đặt lịch khám bệnh thành công.\n";
                body += $"Thông tin lịch hẹn:\n";
                body += $"Ngày khám: {viewModel.NgayKham}\n";
                body += $"Ca khám: {viewModel.CaKhamId}\n";
                // Thêm thông tin khác nếu cần

                // Gửi email
                SendEmail(viewModel.BenhNhan.Email, subject, body);*/


                return RedirectToAction("DanhSachPhieuDatLich", "DatLich");
            }

            // Nếu ModelState không hợp lệ, hiển thị lại trang với thông tin lỗi
            ViewBag.KhoaList = new SelectList(_context.Khoas.ToList(), "idKhoa", "TenKhoa");
            ViewBag.CaKhamList = new SelectList(_context.CaKhams.ToList(), "Id", "TenCa");
            return View("Index", viewModel); // Trả về view Index với dữ liệu viewModel để hiển thị lại các thông tin đã nhập và thông báo lỗi.
        }

        public IActionResult DanhSachPhieuDatLich()
        {
            var danhSachPhieuDatLich = _context.PhieuDatLichs
                .Include(p => p.BenhNhan)
                .Include(p => p.CaKham)
                .ToList();

            // Lấy thông tin tên nhân viên từ cơ sở dữ liệu dựa trên idNhanVien trong từng phiếu đặt lịch
            foreach (var phieuDatLich in danhSachPhieuDatLich)
            {
                phieuDatLich.NhanVien = _context.NhanViens.FirstOrDefault(nv => nv.idNhanVien == phieuDatLich.idNhanVien);
            }

            return View(danhSachPhieuDatLich);
        }
        private void SendEmail(string to, string subject, string body)
        {
            // Thông tin cấu hình email (cần cập nhật thông tin của bạn)
            string smtpServer = "smtp.example.com";
            int port = 587;
            string username = "dunggs2020@gmail.com";
            string password = "dung01655950945@dung";

            // Tạo đối tượng SmtpClient
            SmtpClient client = new SmtpClient(smtpServer, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true // Nếu sử dụng SSL
            };

            // Tạo đối tượng MailMessage
            MailMessage mailMessage = new MailMessage(username, to, subject, body)
            {
                IsBodyHtml = false // Nếu body chứa HTML
            };

            // Gửi email
            client.Send(mailMessage);
        }


    }
}
