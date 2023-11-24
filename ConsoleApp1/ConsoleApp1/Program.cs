using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        TcpClient client = new TcpClient();
        client.Connect("106.201.234.93", 12345); // Connect to the public IP address of PC2
        Console.WriteLine("Connected to server on PC2.");

        NetworkStream stream = client.GetStream();
        string message = "Hello, PC2!";
        byte[] data = Encoding.ASCII.GetBytes(message);
        stream.Write(data, 0, data.Length);
        Console.WriteLine($"Sent message to PC2: {message}");

        // Wait for response from the server
        data = new byte[256];
        int bytesRead = stream.Read(data, 0, data.Length);
        string response = Encoding.ASCII.GetString(data, 0, bytesRead);
        Console.WriteLine($"Received response from server: {response}");

        stream.Close();
        client.Close();
        Console.WriteLine("Connection closed. Press any key to exit.");
        Console.ReadKey();
    }
}