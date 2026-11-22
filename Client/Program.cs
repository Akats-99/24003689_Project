using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        string serverIP = "127.0.0.1";
        int port = 8080;

        try
        {
            // 1. Kết nối tới Server
            TcpClient client = new TcpClient(serverIP, port);
            NetworkStream stream = client.GetStream();

            // 2. Nhập chuỗi HOA từ bàn phím
            Console.Write("Nhap chuoi HOA: ");
            string input = Console.ReadLine();

            // 3. Gửi dữ liệu đi
            byte[] sendData = Encoding.UTF8.GetBytes(input);
            stream.Write(sendData, 0, sendData.Length);

            // 4. Nhận kết quả từ Server
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string result = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            // 5. Hiển thị kết quả
            Console.WriteLine("\n--- Ket qua tu Server ---");
            Console.WriteLine(result);

            // Đóng kết nối
            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Loi: " + ex.Message);
        }
        
        Console.WriteLine("\nNhan phim bat ky de thoat...");
        Console.ReadKey();
    }
}
