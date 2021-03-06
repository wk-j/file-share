﻿using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace FileShare {
    class Program {
        static void Connect(String server, int port, String message) {
            // Send
            var data = Encoding.ASCII.GetBytes(message);
            var client = new TcpClient(server, port);
            var stream = client.GetStream();
            stream.Write(data, 0, data.Length);

            // Receive
            var temp = new Byte[256];
            var bytes = stream.Read(temp, 0, temp.Length);
            var responseData = Encoding.ASCII.GetString(temp, 0, bytes);
            Console.WriteLine(responseData);

            stream.Close();
            client.Close();
        }

        static void Main(string[] args) {
            var file = args[0];
            var text = File.ReadAllText(file);
            Connect("termbin.com", 9999, text);
        }
    }
}
