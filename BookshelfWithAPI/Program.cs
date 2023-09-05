using System.Text.Json;
using BookshelfWithAPI.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var filename = "books.json";
if (!File.Exists(filename))
{
    var books = new Book[]
    {
        new Book("1", "Javaprogrammering kort og godt", "Knut Hegna, Arne Maus", "Computing", "2017", "Universitetsforlaget", "05/09/2023")
    };
    
    var json = JsonSerializer.Serialize(books);
    File.WriteAllText(filename, json);
}

app.MapGet("/bookshelf", () =>
{
    var json = File.ReadAllText(filename);
    return JsonSerializer.Deserialize<Book[]>(json);
});

app.UseStaticFiles();
app.Run();