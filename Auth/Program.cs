using Core.Models;
using Infrastructure.DataContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AppDbContext>(
//    options => options.UseSqlite("Data Source=../AppDb.db"));

// Temporary in memory Db for testing purposes
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseInMemoryDatabase("AppDb"));

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.AllowedForNewUsers = false;

    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireDigit = false;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<User>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
