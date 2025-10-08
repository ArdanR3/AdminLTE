// using statements untuk DbContext dan koneksi database
using AdminLTE_011.Data;
using Microsoft.EntityFrameworkCore;
// using statement yang sudah ada
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// =======================================================
// BAGIAN 1: Mendaftarkan semua layanan yang dibutuhkan
// ======================================================

builder.Services.AddControllersWithViews();

// MENAMBAHKAN KONEKSI DATABASE (DbContext)
// Kode ini membaca connection string dari appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Menambahkan dan mengkonfigurasi layanan otentikasi berbasis cookie
builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
    options.LoginPath = "/Account/Login";
});


// ===================================
// BAGIAN 2: Membangun aplikasi
// ===================================
var app = builder.Build();


// ========================================================
// BAGIAN 3: Mengatur alur request (Middleware Pipeline)
// ========================================================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Urutan ini sangat penting:
app.UseAuthentication();
app.UseAuthorization();

// Mengatur rute default aplikasi
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// ===================================
// BAGIAN 4: Menjalankan aplikasi
// ===================================
app.Run();