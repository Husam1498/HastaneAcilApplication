using AplicationWebUi.identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MsSQLContext>(options =>
    options.UseSqlServer("Server=DESKTOP-S32BE3K;Database=HastaneAcilServisDb; Trusted_Connection=True; TrustServerCertificate=True;")//veritaban� ba��lant�s� yapt�k identity i�in

);
builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<MsSQLContext>().AddDefaultTokenProviders();//kullan�c� login oldu�unda cookide benzersiz bir token olu�turur




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

app.UseAuthentication();//identyty i�in
app.UseRouting();
app.UseAuthorization();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
