using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAdminDatLichPhongKham.Models;

namespace WebAdminDatLichPhongKham.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // Lịch sử hình thành và phát triển
        public IActionResult LichSuHinhThanhVaPhatTrien()
        {
            return View();
        }
        // Cơ sở vật chất và trang thiết bị
        public IActionResult CoSoVatChatVaTrangThietBi()
        {
            return View();
        }
        // Chứng chỉ chứng nhận
        public IActionResult ChungChiChungNhan()
        {
            return View();
        }
        // Báo chí nói về chúng tôi
        public IActionResult BaoChiNoiVeChungToi()
        {
            return View();
        }
        // Video
        public IActionResult Video()
        {
            return View();
        }
        // Lấy mẫu xét nghiệm tận nơi
        public IActionResult LayMauXetNghiemTanNoi()
        {
            return View();
        }
        // Chuyên khoa y tế
        public IActionResult ChuyenKhoaYTe()
        {
            return View();
        }
		/* Danh sách địa chỉ phòng khám */
		public IActionResult ListAddressMEDLATEC()
		{
			return View();
		}
		/* Danh sách văn phòng lấy mẫu */
		public IActionResult ListOfficeMEDLATEC()
		{
			return View();
		}
		/* Danh sách chi nhánh các tỉnh */
		public IActionResult ListBranchMEDLATEC()
		{
			return View();
		}
		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
