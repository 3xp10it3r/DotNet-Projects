using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var samplePerson = new Person { UserName = "Alice", Age = 30 };

app.MapGet("/", () => samplePerson);

app.MapGet("/manual-json", () =>
{
    var json = JsonSerializer.Serialize(samplePerson);
    return TypedResults.Text(json, "application/json");
});


app.MapGet("/custom-json", () =>
{
    var options = new JsonSerializerOptions {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    var json = JsonSerializer.Serialize(samplePerson, options);
    return TypedResults.Text(json, "application/json");
});

app.MapGet("/auto", () => TypedResults.Json(samplePerson));

app.Run();


public class Person
{
    required public string UserName { get; set; }
    required public int Age { get; set; }
}