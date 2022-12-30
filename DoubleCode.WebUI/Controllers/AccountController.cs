using DoubleCode.Application.Interfaces.Accounts;
using DoubleCode.Application.ViewModels.Accounts;
using DoubleCode.Domain.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Threading.Tasks;

namespace DoubleCode.WebUI.Controllers

{
    public class AccountController : Controller
    {
        #region Fields

        private readonly IAccountService _accountService;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        #endregion

        #region Ctor
        public AccountController(IAccountService accountService,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _accountService = accountService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        #endregion

        #region Methods

        #region Register

        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterAccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await _accountService.IsDuplicatedEmail(model.UserName))
            {
                ModelState.AddModelError("UserName", "از این نام کاربری نمی توانید استفاده کنید");
                return View(model);
            }

            if (await _accountService.IsDuplicatedEmail(model.Email))
            {
                ModelState.AddModelError("Email", "قبلا کاربری با این ایمیل ثبت نام کرده است");
                return View(model);
            }

            if (await _accountService.IsDuplicatedEmail(model.UserName))
            {
                ModelState.AddModelError("UserName", "قبلا کاربری با این نام کاربری ثبت نام کرده است");
                return View(model);
            }
            if (await _accountService.RegisterAsync(model))
                return RedirectToAction("Login", "Account");
            else
                return View(model);

        }
        #endregion

        #region Login
        // Get: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginAccountViewModel model, string? returnUrl)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");
            ViewData["returnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return RedirectToAction("Index", "Home");
                }

                if (result.IsLockedOut)
                {
                    ViewData["ErrorMessage"] = "اکانت شما به دلیل پنج بار ورود ناموفق به مدت پنج دقیق قفل شده است";
                    return View(model);
                }

                ModelState.AddModelError("", "رمزعبور یا نام کاربری اشتباه است");
            }
            return View(model);
        }


        #endregion

        #region LogOut

        // GET: /Account/Logout
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region EmailInUse
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return Json(true);
            return Json("ایمیل وارد شده از قبل موجود است");
        }
        #endregion

        #region UserNameInUse
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsUserNameInUse(string userName)
        {
            var exists = await _userManager.FindByEmailAsync(userName);
            if (exists == null)
                return Json(data: true);
            else
                return Json(data: false);

            //var user = await _userManager.FindByNameAsync(userName);
            //if (user == null) return Json("نام کاربری وارد شده درست است");
            //return Json("نام کاربری وارد شده از قبل موجود است");
        }
        #endregion

        #endregion

    }
}