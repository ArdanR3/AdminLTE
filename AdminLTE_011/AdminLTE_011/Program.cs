using AdminLTE_011.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// =======================================================
// BAGIAN 1: Mendaftarkan semua layanan
// =======================================================

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
    options.LoginPath = "/Account/Login";
});

// TAMBAHKAN DUA BARIS INI UNTUK SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ===================================
// BAGIAN 2: Membangun aplikasi
// ===================================
var app = builder.Build();


// ========================================================
// BAGIAN 3: Mengatur alur request
// ========================================================

// Configure the HTTP request pipeline.
// Kita hanya menampilkan Swagger di environment Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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

// Ubah MapControllerRoute menjadi MapControllers untuk API
app.MapControllers();

// Tambahkan lagi MapControllerRoute untuk MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// ===================================
// BAGIAN 4: Menjalankan aplikasi
// ===================================
app.Run();