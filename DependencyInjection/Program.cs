var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddSingleton<IMyService, MyService>(); // throughout same instance
// builder.Services.AddScoped<IMyService, MyService>(); // per request
builder.Services.AddTransient<IMyService, MyService>(); // new instance every time


var app = builder.Build();


app.Use(async (context, next) =>
{
   var myService = context.RequestServices.GetRequiredService<IMyService>(); 
   myService.logCreation("Middleware 1 ");
   await next.Invoke();
});

app.Use(async (context, next) =>
{
   var myService = context.RequestServices.GetRequiredService<IMyService>(); 
   myService.logCreation("Middleware 2");
   await next.Invoke();
});


app.MapGet("/", (IMyService myService) =>
{
    myService.logCreation("root");
    return Results.Ok("Hello");
});


app.Run();


public interface IMyService
{
    void logCreation(string message);
}


public class MyService : IMyService
{
    private readonly int serviceId;
    public MyService()
    {
        serviceId = new Random().Next(10000, 999999);
    }

    public void logCreation(string message = "")
    {
        Console.WriteLine($"{message} ID: {serviceId}");
    }
}