using DoubleCode.Application.Interfaces.UserPanels;
using DoubleCode.Application.ViewModels.UserPanels;
using DoubleCode.Domain.Entities.Users;
using DoubleCode.Infrastructure.Context;
using DoubleCode.WebUI.Areas.UserPanel.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoubleCode.WebUI.Areas.UserPanel.Controllers
{
    public class UserPanelController : BaseUserPanelController
    {
        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        #endregion

        #region Ctor
        public UserPanelController(
            UserManager<User> userManager,
            SignInManager<User> signInManager)

        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #endregion

        #region Index
        public async Task<IActionResult> Index()
        {
            return View(/*await _userpanel.GetUserInformation(User.Identity.Name)*/);
        }
        #endregion

        #region EditProfile

        [Route("EditProfile")]
        public async Task<IActionResult> EditProfile()
        {
            return View(await _userManager.FindByNameAsync(User.Identity.Name));
        }

        [Route("EditProfile")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(string username, EditProfileViewModel profile)
        {
            if (!ModelState.IsValid)
                return View(profile);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (profile.UserName == user.UserName)
            {
                await _userManager.SetUserNameAsync(user, profile.UserName);
            }

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }
        #endregion

        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }

        [Route("ChangePassword")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var username = await _userManager.FindByNameAsync(User.Identity.Name);
            var currentpassword = model.CurrentPassword;
            var newpassword = model.NewPassword;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await _userManager.CheckPasswordAsync(username, currentpassword))
            {
                ModelState.AddModelError("OldPassword", "کلمه عبور فعلی صحیح نمی باشد !");
                return View(model);
            }
            await _userManager.ChangePasswordAsync(username, currentpassword, newpassword);

            return Redirect("auth/Login");
        }
    }
}