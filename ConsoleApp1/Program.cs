using Grpc.Net.Client;
using GrpcService1;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var request = new HelloRequest
            {
                Name = "Mr. X"

            };
            var response=await client.SayHelloAsync(request);
            var response2 = await client.SayHelloAsync(request);
            Console.WriteLine(response.Message);
            Console.WriteLine(response2.Message);
            Console.WriteLine("Press <Enter> for 3. request ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            var response3 = await client.SayHelloAsync(request);
            Console.WriteLine(response3.Message);
            Console.WriteLine("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
    }
}
