using DoubleCode.Application.Services.Account.Command;
using DoubleCode.Application.Services.Account.Query;
using DoubleCode.Application.Services.Account.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoubleCode.WebUI.Controllers;
public class AccountController : Controller
{
    public IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Login

    [AllowAnonymous]
    [Route("login")]
    public IActionResult Login(string retutnURL = null)
    {
        ViewData["retutnURL"] = retutnURL;
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("login")]
    public async Task<IActionResult> Login([FromForm] LoginUser_VM model, string retutnURL = null)
    {
        var checkMatch = await _mediator.Send(new CheckUserNameAndPasswordMatchQuery { LoginUser_VM = model });
        if (checkMatch.Code != 0)
            ModelState.AddModelError(model.Password, checkMatch.Message);

        ViewData["retutnURL"] = retutnURL;
        if (ModelState.IsValid)
        {
            var user = await _mediator.Send(new GetUserByUserNameQuery { UserName = model.UserName });
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Result.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Result.UserName),
                new Claim(ClaimTypes.Email,user.Result.Email)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            };
            await HttpContext.SignInAsync(principal, properties);

            if (!string.IsNullOrEmpty(retutnURL) && Url.IsLocalUrl(retutnURL))
                return RedirectToAction(retutnURL);

            return RedirectToAction("Index", "Home");
        }
        return View(model);
    }

    #endregion Login

    #region Register

    [Route("register")]
    public IActionResult Register()
    {
        return View();
    }

    [Route("register")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([FromForm] RegisterUser_VM register)
    {
        if (ModelState.IsValid)
        {
            // Check Duplicated Email
            var checkEmail = await _mediator.Send(new CheckDuplicatedEmailQuery { Email = register.Email });
            if (checkEmail.Result == false)
            {
                ModelState.AddModelError(nameof(register.Email), checkEmail.Message);
                return View(register);
            }

            // Check Duplicated UserName
            var checkUserName = await _mediator.Send(new CheckDuplicatedUserNameQuery { UserName = register.UserName });
            if (checkUserName.Result == false)
            {
                ModelState.AddModelError(nameof(register.UserName), checkUserName.Message);
                return View(register);
            }

            var regisrer = await _mediator.Send(new RegisterUserCommand { RegisterUser_VM = register });
            if (regisrer.Result == false)
            {
                ModelState.AddModelError(nameof(register.Password), regisrer.Message);
                return View(register);
            }
        }
        else
        {
            return View(register);
        }

        //TODO: Activation Send Email
        //TODO: Redirect to succssesfullView

        return RedirectToAction("Login", "Account");
    }

    #endregion Register

    #region Logout

    [ValidateAntiForgeryToken]
    [Route("Logout")]
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();

        return RedirectToAction("index", "Home");
    }

    #endregion

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> IsUserNameInUse(string userName)
    {
        var user = await _mediator.Send(new GetUserByUserNameQuery { UserName = userName });
        if (user == null) return Json(true);
        return Json("نام کاربری وارد شده از قبل موجود است");
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> IsEmailInUse(string email)
    {
        var user = await _mediator.Send(new GetUserByEmailQuery { Email = email });
        if (user == null) return Json(true);
        return Json("ایمیل وارد شده از قبل موجود است");
    }

    [Route("AccessDenied")]
    public IActionResult AccessDenied()
    {
        return View();
    }
}