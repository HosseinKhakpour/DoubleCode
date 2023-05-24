using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MediatR;
using DoubleCode.Application.Services.Account.ViewModel;
using DoubleCode.Application.Services.Account.Query;
using DoubleCode.Domain.Base;
using Microsoft.Win32;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DoubleCode.Application.Services.Account.Command;

namespace DoubleCode.WebAPI.Controllers
{
    [Route("auth")]
    public class AccountController : Controller
    {
        public IMediator _mediator { get; }

        public AccountController(IMediator mediator)
        {
            _mediator=mediator;
        }

        #region Login
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUser_VM model)
        {

            var checkMatch = await _mediator.Send(new CheckEmailAndPasswordMatch { Email =model.Email, Password=model.Password });
            if (checkMatch.Result == false)
                ModelState.AddModelError(model.Password, checkMatch.Message);

            if (ModelState.IsValid)
            {
                var user = await _mediator.Send(new GetUserByEmailQuery { Email =model.Email });
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

                return RedirectToAction("Index", "Home");

            }
            return View(model);
        }
        #endregion

        #region Register
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUser_VM register)
        {
            if (ModelState.IsValid)
            {
                // Check Duplicated Email
                var checkEmail = await _mediator.Send(new CheckDuplicatedEmailQuery { Email = register.Email });
                if (checkEmail.Result == false)
                    ModelState.AddModelError(nameof(register.Email), checkEmail.Message);

                // Check Duplicated UserName
                var checkUserName = await _mediator.Send(new CheckDuplicatedUserNameQuery { UserName = register.UserName });
                if (checkUserName.Result == false)
                    ModelState.AddModelError(nameof(register.UserName), checkUserName.Message);

                 await _mediator.Send(new RegisterUserCommand { RegisterUser_VM = register});
            }
            else
            {
                return View(register);
            }

            //TODO: Activation Send Email
            //TODO: Redirect to succssesfullView

            return RedirectToAction("Login", "Account");
        }
        #endregion

        #region Logout
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }

}
