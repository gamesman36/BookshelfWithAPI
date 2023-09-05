using System.Text.Json;
using BookshelfWithAPI.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var filename = "books.json";

app.MapGet("/bookshelf", () =>
{
    var json = File.ReadAllText(filename);
    return JsonSerializer.Deserialize<Book[]>(json);
});

app.UseStaticFiles();
app.Run();