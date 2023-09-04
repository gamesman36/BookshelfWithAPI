var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/bookshelf", () =>
{

});

app.UseStaticFiles();
app.Run();