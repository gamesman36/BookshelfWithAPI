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
app.MapDelete("/bookshelf/{id}", (HttpContext context, int id) =>
{
    var books = GetAllBooks().ToList();
    var bookToRemove = books.FirstOrDefault(book => book.Id == id);
    if (bookToRemove != null)
    {
        books.Remove(bookToRemove);
        SaveToFile(books);
        context.Response.StatusCode = StatusCodes.Status204NoContent;
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
    }
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