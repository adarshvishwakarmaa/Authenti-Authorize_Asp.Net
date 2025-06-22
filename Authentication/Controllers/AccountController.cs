using Authentication.Entities;
using Authentication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Authentication.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthenticationDbContext context;
        public AccountController(AuthenticationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Users.ToList());
        }
        public IActionResult Registration()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid) {
                UserAccount account = new UserAccount();
                account.Email = model.Email;
                account.FirstName = model.FirstName;
                account.LastName = model.LastName;
                account.Password = model.Password;
                account.UserName = model.UserName;

                try
                {
                    context.Users.Add(account);
                    context.SaveChanges();

                    ModelState.Clear();
                    ViewBag.Message = $"{account.FirstName} {account.LastName} registered successufly. Please Login";
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "Please entewr unique Email or Password.");
                    return View(model);
                }
                return View();
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid) { 
                var user = context.Users.Where(a=>(a.UserName == model.UserNameOrEmail || a.Email ==model.UserNameOrEmail) && a.Password ==model.Password).FirstOrDefault();
                if (user != null) {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,user.Email),
                        new Claim("Name",user.FirstName),
                        new Claim(ClaimTypes.Role,"User"),
                    };
                    var claimsIdentity =new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("SecurePage");
                }
                else
                {
                    ModelState.AddModelError("", "Username/Email or Password is not Correct");
                }
              
            }
            return View(model);
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult SecurePage()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }
    }
}
