using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using TCP.ServerJsonClientHandler.TCP.ServerJsonClientHandler;

namespace TCP.ServerJsonClientHandler
{
    public class ClientHandler
    {
        public static async Task HandleClient(TcpClient client)
        {
            Console.WriteLine($"Client connected: {client.Client.RemoteEndPoint}");
            NetworkStream ns = client.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

            try
            {
                while (true) 
                {
                    string jsonString = await reader.ReadLineAsync();
                    if (string.IsNullOrWhiteSpace(jsonString))
                        break;

                    var request = JsonSerializer.Deserialize<Request>(jsonString);
                    Console.WriteLine("Received JSON data: " + jsonString);

                    Answers response = new Answers { Method = request.Method };

                    switch (request.Method.ToLower()) 
                    {
                        case "random":
                            response.Num1 = request.Tal1;
                            response.Num2 = request.Tal2;
                            response.Result = new Random().Next(request.Tal1, request.Tal2);
                            break;

                        case "add":
                            response.Num1 = request.Tal1;
                            response.Num2 = request.Tal2;
                            response.Result = request.Tal1 + request.Tal2;
                            break;

                        case "subtract":
                            response.Num1 = request.Tal1;
                            response.Num2 = request.Tal2;
                            response.Result = request.Tal1 - request.Tal2;
                            break;

                        //case "close":
                        //    Console.WriteLine("Closing connection...");
                        //    response.Method = "close";
                        //    await writer.WriteLineAsync(JsonSerializer.Serialize(response));
                        //    return; 

                        default:
                            response.Method = "Overhold protokollen, tak!";
                            response.Result = 0;
                            break;
                    }

                    
                    await writer.WriteLineAsync(JsonSerializer.Serialize(response));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error handling client: " + ex.Message);
            }
            finally
            {
                client.Close();
                Console.WriteLine("Client disconnected.");
            }
        }
    }
}

