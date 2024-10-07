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
    options.Password.RequireDigit = false;              //digit required
    options.Password.RequiredLength = 1;                //length
    options.Password.RequireNonAlphanumeric = false;    //special character required
    options.Password.RequireUppercase = false;          //uppercase letter required
    options.Password.RequireLowercase = false;          //lowercase letter required
    options.Password.RequiredUniqueChars = 0;           //unique characters required
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
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserTasks}/{action=Index}/{id?}");
app.MapRazorPages(); 

app.Run();
