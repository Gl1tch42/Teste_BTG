using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<MyContext>
    (opt => opt.UseMySql(
        "server=localhost;User Id=root;Password=1234;Database=btg",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql")
    ));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<IProgrammingLanguageService, ProgrammingLanguageService>();
builder.Services.AddScoped<IGitService, GitService>();



var app = builder.Build();

app.UseAuthorization();

app.MapControllers();


app.Run();
