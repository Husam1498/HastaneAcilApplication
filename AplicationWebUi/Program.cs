using AplicationWebUi.identity;
using Bussiness.Abstract;
using Bussiness.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EfCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MsSQLContext>(options =>
    options.UseSqlServer("Server=DESKTOP-S32BE3K;Database=HastaneAcilServisDb; Trusted_Connection=True; TrustServerCertificate=True;")//veritabaný baððlantýsý yaptýk identity için

);
builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<MsSQLContext>().AddDefaultTokenProviders();//kullanýcý login olduðunda cookide benzersiz bir token oluþturur

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequireDigit = true;

    opt.Lockout.MaxFailedAccessAttempts = 5;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(5);
    opt.Lockout.AllowedForNewUsers = true;

    opt.User.RequireUniqueEmail = true;
    //opt.SignIn.RequireConfirmedEmail = true;//Kullanýcý kayýt olurken emailini doðrulamasý gerekr
});
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath="/Kullanici/Login";
    opt.LogoutPath = "/Kullanici/Logout";
    opt.AccessDeniedPath = "/Kullanici/AccessDenied";

    opt.SlidingExpiration = true;
    opt.ExpireTimeSpan = TimeSpan.FromDays(5);

    opt.Cookie = new CookieBuilder
    {
        HttpOnly = true,//javascript uygulamlarý cokiye ulaþmaamýs için
        Name=".HastaneCookies"
    };

});

builder.Services.AddScoped<IAcilServisAlanRepository, EfCoreAcilAlanRepository>();

builder.Services.AddScoped<IAcilServisAlanService, AcilServisAlanManager>();


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
