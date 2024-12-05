using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Добавление Swagger и XML комментариев к коду в swagger
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(
        AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), true);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapGet("/api/getsfolder", () =>
{
    string relativePath = @"DB";
    var p = AppDomain.CurrentDomain.BaseDirectory;
    //var projectDir = Path.GetDirectoryName();
    //var folder = Environment.SpecialFolder.LocalApplicationData;
    //var path = Environment.GetFolderPath(folder);
    var path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();

    string filePath = Path.Combine(path, relativePath);
    return Results.Json(filePath);
});

app.MapControllers();

app.Run();


