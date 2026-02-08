// Week 9 Day 4 - Dependency Injection & API setup

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TaskSales.Application.Interfaces;
using TaskSales.Infrastructure.Data;
using TaskSales.Infrastructure.Mongo;
using TaskSales.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// ===============================
// AUTHENTICATION (COOKIE)
// ===============================
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Identity/Account/Login";
        options.AccessDeniedPath = "/Identity/Account/AccessDenied";
        options.Cookie.SameSite = SameSiteMode.None;   // required for Blazor
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    });

builder.Services.AddAuthorization();

// ===============================
// CORS (Blazor → API)
// ===============================
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7053")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// ===============================
// DATABASE (SQL SERVER)
// ===============================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlConnection")));

// ===============================
// APPLICATION SERVICES
// ===============================
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISalesReportService, SalesReportService>();
builder.Services.AddScoped<ISchedulerService, SchedulerService>();

// ===============================
// MONGO SERVICE
// ===============================
var mongoSettings = builder.Configuration.GetSection("MongoSettings");

builder.Services.AddSingleton(
    new MongoDbService(
        mongoSettings["ConnectionString"]!,
        mongoSettings["DatabaseName"]!
    ));

// ===============================
// CONTROLLERS + SWAGGER
// ===============================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ===============================
// MIDDLEWARE
// ===============================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("BlazorPolicy"); // must be before auth

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

// 🔥 REQUIRED FOR INTEGRATION TESTING
public partial class Program { }