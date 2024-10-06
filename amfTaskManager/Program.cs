using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using amfTaskManager.Data;
using amfTaskManager.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Configure Identity with your custom AppUser class
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;              // No digit required
    options.Password.RequiredLength = 1;                // Minimum length
    options.Password.RequireNonAlphanumeric = false;    // No special character required
    options.Password.RequireUppercase = false;          // No uppercase letter required
    options.Password.RequireLowercase = false;          // No lowercase letter required
    options.Password.RequiredUniqueChars = 0;           // No unique characters required
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // Enables authentication
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserTasks}/{action=Index}/{id?}");
app.MapRazorPages(); // Enables Identity pages

app.Run();
