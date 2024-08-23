using AplicationWebUi.identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MsSQLContext>(options =>
    options.UseSqlServer("Server=DESKTOP-S32BE3K;Database=HastaneAcilServisDb; Trusted_Connection=True; TrustServerCertificate=True;")//veritabaný baððlantýsý yaptýk identity için

);
builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<MsSQLContext>().AddDefaultTokenProviders();//kullanýcý login olduðunda cookide benzersiz bir token oluþturur




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
