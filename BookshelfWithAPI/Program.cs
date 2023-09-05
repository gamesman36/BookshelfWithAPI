using BookshelfWithAPI.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/bookshelf", () =>
{
    return new Book[]
    {
        new Book("1", "Javaprogrammering kort og godt", "Knut Hegna, Arne Maus", "Computing", "2017", "Universitetsforlaget", "05/09/2023")
    };
});

app.UseStaticFiles();
app.Run();