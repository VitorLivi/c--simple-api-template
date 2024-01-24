var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/shirts", () =>
{
    return "Read all shirts";
});

app.MapGet("/shirts/{id}", (int id) =>
{
    return $"Read shirt {id}";
});

app.MapPost("/shirts", () =>
{
    return "Create a shirt";
});

app.MapPut("/shirt/{id}", (int id) =>
{
    return $"Update shirt {id}";
});

app.MapDelete("/shirt/{id}", (int id) =>
{
    return $"Delete shirt {id}";
});

app.UseHttpsRedirection();
app.Run();
