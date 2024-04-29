//Devin skipps
//C00440885
using Grpc.Net.Client;
using GrpcGreeterClient;
Console.Write("Enter name: ");
var name = Console.ReadLine();
 
// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("http://localhost:5034");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(
    new HelloRequest { Name = name });
 
Console.WriteLine(reply.Message);
