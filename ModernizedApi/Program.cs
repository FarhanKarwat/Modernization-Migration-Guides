using Microsoft.EntityFrameworkCore;
using ModernizedApi.Data;
using ModernizedApi.Services;

var builder = WebApplication.CreateBuilder(args);

// CORS for local Angular dev
builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
    p.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")));

// EF Core InMemory for demo
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("DemoDb"));

// Services
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed sample data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!db.Users.Any())
    {
        db.Users.AddRange(
            new ModernizedApi.Models.User { Id = 1, Name = "Alice" },
            new ModernizedApi.Models.User { Id = 2, Name = "Bob" }
        );
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.MapControllers();

app.Urls.Add("http://localhost:5178");

app.Run();
