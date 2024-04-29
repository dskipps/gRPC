using Grpc.Core;
using GrpcService1;

namespace GrpcService1.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;

    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = GetMessagesFromDb(request.Name)
        });
    }
    public static string UTC()
    {
        return DateTime.Now.ToUniversalTime().ToString() + " UTC";
    }
    static string GetMessagesFromDb(string name) {
        using var db = new MessagesContext();
        var results = from me in db.Messages where me.Name == name select me; 
        if (results.Count() == 0) { 
            return $"No messages for {name}"; 
        }
        string messageList = $"Messages for {name}\n"; 
        foreach (var m in results){ 
            messageList += $" {m.MessageText}\n"; 
            return messageList; 
        }
        return $"No messages for {name}";
    }
}