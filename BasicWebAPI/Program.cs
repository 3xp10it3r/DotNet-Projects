var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var blogs = new List<Blog>
{
  new Blog { Title = "First Post", Content = "This is my first blog post." },
  new Blog { Title = "Second Post", Content = "This is my second blog post." }  
};


app.MapGet("/", () => "Im root!");
app.MapGet("/blogs", () => blogs);
app.MapPost("/blogs", (Blog blog) =>
{
    blogs.Add(blog);
    return Results.Created($"blogs/{blogs.Count - 1}", blog);
});

app.MapGet("/blogs/{id}", (int id) =>
{
    if(id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }

    return Results.Ok(blogs[id]);
});


app.MapDelete("/blogs/{id}", (int id) =>
{
    if(id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }

    blogs.RemoveAt(id);
    return Results.NoContent();
});

app.MapPut("/blogs/{id}", (int id, Blog updatedBlog) =>
{
    if(id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }

    blogs[id] = updatedBlog;
    return Results.Ok(blogs[id]);
});


app.Run();



public class Blog
{
    public string Title { get; set; }
    public string Content { get; set; }
}