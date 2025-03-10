using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using TCP.ServerJsonClientHandler;

Console.WriteLine("TCP Server");

int port = 2000;
TcpListener listener = new TcpListener(IPAddress.Any, port);
listener.Start();

while (true)
{
    TcpClient client = await listener.AcceptTcpClientAsync();
    _ = Task.Run(() => ClientHandler.HandleClient(client));
}
