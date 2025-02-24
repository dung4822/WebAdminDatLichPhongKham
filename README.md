# Hệ thống Quản lý Đặt lịch Khám bệnh MEDLATEC

## 📝 Mô tả
Một hệ thống quản lý đặt lịch khám bệnh toàn diện cho Bệnh viện Đa khoa MEDLATEC, được phát triển bằng ASP.NET Core MVC. Hệ thống giúp tối ưu hóa quy trình đặt lịch khám bệnh, quản lý thông tin bệnh nhân và điều phối nguồn lực y tế một cách hiệu quả.

## ✨ Tính năng chính

### 👥 Quản lý người dùng
- Đăng ký/đăng nhập với nhiều vai trò (Admin, Bác sĩ, Bệnh nhân)
- Phân quyền chi tiết theo từng chức năng
- Quản lý thông tin cá nhân

### 👨‍⚕️ Quản lý nhân viên y tế
- Thêm/sửa/xóa thông tin nhân viên
- Phân công ca làm việc
- Quản lý chuyên khoa và chức vụ
- Theo dõi lịch làm việc

### 📅 Đặt lịch khám
- Đặt lịch khám trực tuyến
- Chọn bác sĩ và thời gian phù hợp
- Nhận thông báo qua email
- Quản lý lịch hẹn

### 📋 Quản lý hồ sơ bệnh án
- Lưu trữ thông tin bệnh án
- Tra cứu lịch sử khám bệnh
- Cập nhật tình trạng sức khỏe
- Xuất báo cáo

## 🛠 Công nghệ sử dụng

### Backend
- ASP.NET Core MVC 6.0
- Entity Framework Core
- SQL Server
- Identity Framework
- SMTP Email

### Frontend
- HTML5/CSS3
- Bootstrap 5
- JavaScript
- jQuery

## 🏗 Kiến trúc hệ thống
- Mô hình MVC (Model-View-Controller)
- Repository Pattern
- Dependency Injection
- Code First Database

## 📦 Cài đặt và Chạy

### Yêu cầu hệ thống
- .NET 6.0 SDK
- SQL Server
- Visual Studio 2022 (khuyến nghị)

### Các bước cài đặt

1. Clone repository:
bash
git clone https://github.com/dung4822/WebAdminDatLichPhongKham.git

2. Cập nhật connection string trong `appsettings.json`

3. Chạy migration:
bash
dotnet ef database update

4. Build và chạy ứng dụng:
bash 
dotnet run

## 🔒 Bảo mật
- Xác thực người dùng với ASP.NET Core Identity
- Mã hóa mật khẩu
- CSRF Protection
- XSS Prevention
- SQL Injection Prevention

## 🎯 Mục tiêu phát triển
- [ ] Tích hợp thanh toán trực tuyến
- [ ] Thêm tính năng chat trực tuyến
- [ ] Phát triển ứng dụng mobile
- [ ] Tối ưu hóa hiệu năng
- [ ] Thêm tính năng đánh giá bác sĩ

## 👥 Đóng góp
Mọi đóng góp đều được chào đón. Vui lòng:

1. Fork dự án
2. Tạo branch mới (`git checkout -b feature/AmazingFeature`)
3. Commit thay đổi (`git commit -m 'Add some AmazingFeature'`)
4. Push lên branch (`git push origin feature/AmazingFeature`)
5. Tạo Pull Request

## 📄 Giấy phép
Dự án được phân phối dưới giấy phép MIT. Xem `LICENSE` để biết thêm thông tin.

## 📧 Liên hệ
Nguyễn Đức Dũng - dunggs2020@gmail.com

Link Github: [https://github.com/dung4822/WebAdminDatLichPhongKham]
---
*Dự án này được phát triển như một phần của đồ án cơ sở tại [HUTECH]*
