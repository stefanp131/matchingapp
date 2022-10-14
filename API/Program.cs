var builder = WebApplication.CreateBuilder(args);

// add services to the container

builder.Services.AddControllers();
builder.Services.AddCors();

//Configure the HTTP request pipeline

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("https://localhost:4200"));

app.MapControllers();

app.Run();
