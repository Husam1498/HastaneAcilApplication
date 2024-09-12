
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
//builder.Services.AddDbContext<MsSQLContext>(options =>
//    options.UseSqlServer("Server=DESKTOP-S32BE3K;Database=HastaneAcilServisDb; Trusted_Connection=True; TrustServerCertificate=True;")//veritabaný baððlantýsý yaptýk identity için

//);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opts =>
    {
        opts.Cookie.Name = "HastaneApplicationCookies.auth";
        opts.SlidingExpiration = true;
        opts.ExpireTimeSpan = TimeSpan.FromDays(5);
        opts.LoginPath = "/Kullanici/Login";
        opts.LogoutPath = "/Kullanici/Logout";
        opts.AccessDeniedPath = "/Kullanici/AccessDenied";

    });

//builder.Services.ConfigureApplicationCookie(opt =>
//{
//    opt.LoginPath="/Kullanici/Login";
//    opt.LogoutPath = "/Kullanici/Logout";
//    opt.AccessDeniedPath = "/Kullanici/AccessDenied";

//    opt.SlidingExpiration = true;
//    opt.ExpireTimeSpan = TimeSpan.FromDays(5);
//});

builder.Services.AddScoped<IAcilServisAlanRepository, EfCoreAcilAlanRepository>();
builder.Services.AddScoped<IDoktorRepository, EfCoreDoktorRepository>();
builder.Services.AddScoped<IHastaRepository, EfCoreHastaRepository>();
builder.Services.AddScoped<IUserRepository, EfCoreUserRepository>();

builder.Services.AddScoped<IAcilServisAlanService, AcilServisAlanManager>();
builder.Services.AddScoped<IDoktorService, DoktorManager>();
builder.Services.AddScoped<IHastaService, HastaManager>();
builder.Services.AddScoped<IUserService, UserManager>();


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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
