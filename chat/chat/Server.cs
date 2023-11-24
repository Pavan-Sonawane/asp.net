using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Parse("0.0.0.0"), 12345);
        server.Start();
        Console.WriteLine("Server started. Waiting for clients...");

        TcpClient client = server.AcceptTcpClient();
        NetworkStream stream = client.GetStream();

        byte[] data = new byte[256];
        int bytesRead = stream.Read(data, 0, data.Length);
        string message = Encoding.ASCII.GetString(data, 0, bytesRead);
        Console.WriteLine($"Received message from PC 1: {message}");

        stream.Close();
        client.Close();
        server.Stop();
        Console.WriteLine("Server stopped.");
    }
}
