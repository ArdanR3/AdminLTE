using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (username == "ardan@gmail.com" && password == "1")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim("FullName", "Administrator")
            };

            var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuth");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

            return RedirectToAction("Index", "Dashboard");
        }

        ViewData["ErrorMessage"] = "Username atau Password salah.";
        return View();
    }

    // TAMBAHKAN METHOD BARU DI BAWAH INI
    public async Task<IActionResult> Logout()
    {
        // Perintah ini akan menghapus cookie login pengguna
        await HttpContext.SignOutAsync("MyCookieAuth");

        // Arahkan pengguna kembali ke halaman login
        return RedirectToAction("Login", "Account");
    }
}