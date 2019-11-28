using System;
using System.IO;
using System.Net.Sockets;

namespace FileShare {
    class Program {
        static void Connect(String server, int port, String message) {
            try {
                // Send
                var data = System.Text.Encoding.ASCII.GetBytes(message);
                var client = new TcpClient(server, port);
                var stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                var temp = new Byte[256];
                var bytes = stream.Read(temp, 0, temp.Length);
                var responseData = System.Text.Encoding.ASCII.GetString(temp, 0, bytes);
                Console.WriteLine("{0}", responseData);

                // Close everything.
                stream.Close();
                client.Close();
            } catch (ArgumentNullException e) {
                Console.WriteLine("ArgumentNullException: {0}", e);
            } catch (SocketException e) {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        static void Main(string[] args) {
            var file = args[0];
            var text = File.ReadAllText(file);
            Connect("termbin.com", 9999, text);
        }
    }
}
