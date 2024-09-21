
using AplicationWebUi.Helpers;
using Bussiness.Abstract;
using Bussiness.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opts =>
    {
        opts.Cookie.Name = "HastaneApplicationCookies.auth";
        
        opts.LoginPath = "/Kullanici/Login";
        opts.LogoutPath = "/Kullanici/Logout";
        opts.AccessDeniedPath = "/Kullanici/AccessDenied";
      
        opts.ExpireTimeSpan = TimeSpan.FromDays(2);
        opts.SlidingExpiration = true;

    });

builder.Services.AddScoped<IAcilServisAlanRepository, EfCoreAcilAlanRepository>();
builder.Services.AddScoped<IDoktorRepository, EfCoreDoktorRepository>();
builder.Services.AddScoped<IHastaRepository, EfCoreHastaRepository>();
builder.Services.AddScoped<IUserRepository, EfCoreUserRepository>();

builder.Services.AddScoped<IAcilServisAlanService, AcilServisAlanManager>();
builder.Services.AddScoped<IDoktorService, DoktorManager>();
builder.Services.AddScoped<IHastaService, HastaManager>();
builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddScoped<IHasher, Hasher>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();//identyty için
app.UseRouting();
app.UseAuthorization();


app.UseAuthorization();

app.MapControllerRoute(
    name: "KullanýcýList",
    pattern: "Kullanýcýlar",
    defaults: new { controller = "Admin", action = "UserListPartial" });



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
