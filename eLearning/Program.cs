using eLearning.Data;
using Microsoft.EntityFrameworkCore;
using eLearning.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();


var app = builder.Build();


app.MapControllerRoute(
    name: "login",
    pattern: "/login",
    defaults: new { controller = "Login", action = "Index" });


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    //SeedData(services);
}
/*
if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    Seed.SeedData(app);
}
*/
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
