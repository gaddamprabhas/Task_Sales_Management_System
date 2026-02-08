using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using TaskSales.Blazor.Areas.Identity;
using TaskSales.Blazor.Data;
using TaskSales.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// ===============================
// SYNCFUSION
// ===============================
builder.Services.AddSyncfusionBlazor();

// ===============================
// HTTP CLIENT (COOKIE ENABLED)
// ===============================
builder.Services.AddHttpClient("Api", client =>
{
    client.BaseAddress = new Uri("https://localhost:7081");
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        UseCookies = true,
        AllowAutoRedirect = true
    };
});

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api"));

// ===============================
// API SERVICES
// ===============================
builder.Services.AddScoped<TaskApiService>();
builder.Services.AddScoped<EmployeeApiService>();
builder.Services.AddScoped<SalesApiService>();
builder.Services.AddScoped<FeedbackApiService>();
builder.Services.AddScoped<LogApiService>();
builder.Services.AddScoped<DashboardApiService>();
builder.Services.AddScoped<ReportApiService>();
builder.Services.AddScoped<EmployeeState>();

// ===============================
// DATABASE (IDENTITY)
// ===============================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// ===============================
// IDENTITY
// ===============================
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IEmailSender, DummyEmailSender>();

// ===============================
// BLAZOR
// ===============================
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider,
    RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

var app = builder.Build();

// ===============================
// ROLE SEEDING
// ===============================
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

// ===============================
// MIDDLEWARE
// ===============================
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// ===============================
// SYNCFUSION LICENSE
// ===============================
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
    "Ngo9BigBOggjGyl/VkR+XU9Ff1RDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3hTd0RiWXheeHdQQmBfWE91XQ=="
);

app.Run();
