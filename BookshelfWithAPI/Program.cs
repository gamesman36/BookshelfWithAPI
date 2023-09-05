using System.Text.Json;
using BookshelfWithAPI.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var filename = "books.json";

app.MapGet("/bookshelf", GetAllBooks);
app.MapPost("/bookshelf", (Book book) =>
{
    var books = GetAllBooks().ToList();
    books.Add(book);
    SaveToFile(books);
});

app.UseStaticFiles();
app.Run();

Book[] GetAllBooks()
{
    var json = File.ReadAllText(filename);
    return JsonSerializer.Deserialize<Book[]>(json);
}

void SaveToFile(IEnumerable<Book> books)
{
    var json = JsonSerializer.Serialize(books);
    File.WriteAllText(filename, json);
}