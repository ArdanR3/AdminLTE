using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// 1. Mendaftarkan semua layanan yang dibutuhkan
builder.Services.AddControllersWithViews();

// Menambahkan dan mengkonfigurasi layanan otentikasi berbasis cookie
builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
    options.LoginPath = "/Account/Login"; // Jika pengguna mencoba mengakses halaman yang butuh login, arahkan ke sini
});


// 2. Membangun aplikasi
var app = builder.Build();


// 3. Mengatur alur request (Middleware Pipeline)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Mengizinkan akses ke file di wwwroot (CSS, JS, gambar)

app.UseRouting();

// Urutan ini sangat penting:
app.UseAuthentication(); // Memeriksa siapa pengguna (berdasarkan cookie)
app.UseAuthorization();  // Memeriksa apa yang boleh dilakukan pengguna

// Mengatur rute default aplikasi
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Halaman utama adalah Home/Index


// 4. Menjalankan aplikasi
app.Run();