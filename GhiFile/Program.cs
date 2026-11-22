using System;
using System.IO; // Thư viện cần thiết để làm việc với tệp tin (Input/Output)
using System.Text; // Thư viện hỗ trợ mã hóa tiếng Việt

namespace GhiFileTuBanPhim
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Khai báo các biến để lưu thông tin nhập từ bàn phím
            string tenSV, lop, noiDungGhi;
            string filePath = "KetQuaKiemTra.txt";

            try
            {
                // 2. Nhập thông tin Tên Sinh Viên từ bàn phím
                Console.Write("Nhap ho ten sinh vien: ");
                tenSV = Console.ReadLine();

                // 3. Nhập thông tin Lớp từ bàn phím
                Console.Write("Nhap ten lop: ");
                lop = Console.ReadLine();

                // 4. Gộp các thông tin lại theo định dạng: Tên SV_Lớp_Kiểm tra giữa môn
                noiDungGhi = $"{tenSV}_{lop}_Kiểm tra giữa môn";

                // 5. Thực hiện ghi nội dung đã gộp vào file txt (sử dụng mã hóa UTF-8)
                File.WriteAllText(filePath, noiDungGhi, Encoding.UTF8);

                // 6. Hiển thị thông báo thành công và đường dẫn file
                Console.WriteLine("\n--- KẾT QUẢ ---");
                Console.WriteLine("Da ghi file thanh cong!");
                Console.WriteLine("Noi dung trong file: " + noiDungGhi);
                Console.WriteLine("File luu tai: " + Path.GetFullPath(filePath));
            }
            catch (Exception ex)
            {
                // 7. Xử lý nếu có lỗi trong quá trình nhập hoặc ghi file
                Console.WriteLine("Co loi xay ra: " + ex.Message);
            }

            // 8. Dừng màn hình để người dùng xem kết quả trước khi thoát
            Console.WriteLine("\nNhan phim bat ky de ket thuc...");
            Console.ReadKey();
        }
    }
}
