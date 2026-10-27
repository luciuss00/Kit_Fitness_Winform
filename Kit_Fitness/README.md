# 🏋️‍♂️ KIT FITNESS - WINFORMS APPLICATION

> Ứng dụng theo dõi calo, dinh dưỡng, tủ lạnh thông minh và lộ trình thể trạng cá nhân hóa dành cho môn **Lập Trình Trực Quan (LTTQ)**.

---

## 📌 1. Yêu cầu môi trường (Prerequisites)

Để chạy dự án đồng bộ và trơn tru nhất, máy tính cần cài đặt:
* **Hệ điều hành:** Windows 10 hoặc Windows 11
* **.NET SDK:** .NET 10.0 SDK (hoặc cài Visual Studio 2022 phiên bản mới nhất hỗ trợ .NET 10)
* **Cơ sở dữ liệu:** Microsoft SQL Server (bản Local, Express `.\SQLEXPRESS`, hoặc Developer)
* **Công cụ quản lý DB:** SQL Server Management Studio (SSMS) hoặc Azure Data Studio

---

## 🚀 2. Các bước Setup sau khi Pull code về

### Bước 1: Khởi tạo Cơ sở dữ liệu SQL Server
Trong thư mục dự án đã chuẩn bị sẵn 2 script SQL chuẩn Unicode UTF-8 (`NVARCHAR`):

1. Mở SSMS kết nối vào SQL Server của bạn.
2. Mở file `init_database.sql` và nhấn **Execute** (`F5`). Script sẽ tự tạo Database `KitFitness` cùng 15 bảng nghiệp vụ.
3. Mở file `seed_data.sql` và nhấn **Execute** (`F5`). Script sẽ nạp đầy đủ dữ liệu mẫu (10 dòng liên kết logic mỗi bảng) bao gồm tài khoản, thực phẩm, thực đơn, nhật ký, tủ lạnh.

### Bước 2: Cấu hình Connection String (`appsettings.json`)
File `appsettings.json` chứa mật khẩu/cấu hình cá nhân nên mặc định được đưa vào `.gitignore` để bảo mật.
1. Trong thư mục dự án, tạo file `appsettings.json` bằng cách copy từ file mẫu `appsettings.example.json`.
2. Điều chỉnh chuỗi kết nối phù hợp với SQL Server trên máy bạn:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=KitFitness;Trusted_Connection=True;TrustServerCertificate=True;"
     },
     "ApiSettings": {
       "ApiKey": "YOUR_GEMINI_API_KEY_HERE"
     }
   }
   ```
   *(Nếu dùng SQL Express, đổi `Server=localhost` thành `Server=.\\SQLEXPRESS`)*.

### Bước 3: Build & Chạy ứng dụng
* **Cách 1 (Visual Studio):** Mở solution file hoặc folder dự án trong Visual Studio 2022, chọn project `Kit_Fitness` làm Startup Project và nhấn **F5** (Start Debugging).
* **Cách 2 (Terminal / Command Line):**
  ```bash
  dotnet build
  dotnet run
  ```

---

## 🔑 3. Tài khoản đăng nhập kiểm thử

Dữ liệu mẫu đã có sẵn tài khoản hoàn chỉnh:
* **Tên đăng nhập:** `dat_fitness`
* **Mật khẩu:** `123456`
* **Mã khôi phục (Recovery Code):** `REC-DAT-FITNESS-2026`

*(Hoặc bạn có thể bấm **Đăng ký** tài khoản mới trên giao diện. Khi đăng nhập lần đầu, hệ thống sẽ tự động kích hoạt **Onboarding Wizard** đón tiếp người mới!)*

---

## 🌟 4. Các tính năng & Logic nghiệp vụ nổi bật

1. **Onboarding & Mascot chào mừng người mới (`frmOnboarding`):**
   * Tự động phát hiện tài khoản mới để kích hoạt quy trình khảo sát 5 bước.
   * Tính toán tức thì BMI, BMR (Mifflin-St Jeor), TDEE, và Target Calories chuẩn khoa học.
   * Tính toán bộ 3 Macro: **30% Đạm (Protein)**, **40% Tinh bột (Carb)**, **30% Chất béo (Fat)** quy đổi ra gram.
   * Tính **ETA** (thời gian dự kiến hoàn thành mục tiêu cân nặng theo số tuần).
   * Màn hình vinh danh với **Mascot Kit** và Campaign Badge truyền cảm hứng.
2. **Quy đổi dinh dưỡng theo đơn vị (`ScaleByUnit`):**
   * Đơn vị theo 100g/100ml (`g`, `ml`, `gram`) chia cho 100.
   * Đơn vị đếm (`quả`, `tô`, `bát`, `đĩa`, `hộp`...) nhân trực tiếp số lượng, đảm bảo dinh dưỡng chính xác tuyệt đối.
3. **Hệ thống Traffic Light (Đèn giao thông dinh dưỡng):**
   * **Food Traffic Light:** Phân loại món ăn theo calo ($\le$200: Xanh, $\le$500: Vàng, >500: Đỏ).
   * **Meal Traffic Light:** Đánh giá bữa ăn theo số bữa trong ngày (`mealPerDay`: 1-6 bữa).
   * **Daily Calorie Goal Evaluator:** Đánh giá mức calo cả ngày theo từng mục tiêu riêng biệt (*Giảm mỡ, Giữ dáng, Tăng cân*).
4. **Streak chuỗi ngày liên tục:**
   * Tự động đếm số ngày liên tục người dùng ghi nhật ký ăn uống và hiển thị huy hiệu ngọn lửa (`🔥 X ngày chuỗi`).
5. **Chống trùng nhật ký cân nặng (Upsert Weight Log):**
   * Tự động ghi đè bản ghi cân nặng nếu người dùng nhập nhiều lần trong cùng 1 ngày.
6. **Xóa mềm & Tổng thời gian tập luyện (`WorkoutLog`):**
   * Hỗ trợ soft-delete và thống kê tổng thời gian tập luyện.
