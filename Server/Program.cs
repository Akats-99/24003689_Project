using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;

class Server
{
    static void Main()
    {
        // 1. Cấu hình IP và Port
        int port = 8080;
        TcpListener server = new TcpListener(IPAddress.Any, port);

        // 2. Bắt đầu lắng nghe kết nối
        server.Start();
        Console.WriteLine($"Server dang cho ket noi tai port {port}...");

        while (true)
        {
            // Chấp nhận kết nối từ Client
            using (TcpClient client = server.AcceptTcpClient())
            using (NetworkStream stream = client.GetStream())
            {
                // 3. Nhận dữ liệu từ Client
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string receiveData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Da nhan: {receiveData}");

                // 4. Xử lý logic theo yêu cầu
                int charCount = receiveData.Length; // Số lượng ký tự
                // Đếm số từ bằng cách tách khoảng trắng và loại bỏ phần tử rỗng
                int wordCount = receiveData.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
                string lowerStr = receiveData.ToLower(); // Chuyển thành chữ thường

                // Chuẩn bị chuỗi kết quả phản hồi
                string response = $"So ky tu: {charCount} | So tu: {wordCount} | Chuoi thuong: {lowerStr}";
                byte[] sendData = Encoding.UTF8.GetBytes(response);

                // 5. Gửi kết quả lại cho Client
                stream.Write(sendData, 0, sendData.Length);
            }
        }
    }
}
