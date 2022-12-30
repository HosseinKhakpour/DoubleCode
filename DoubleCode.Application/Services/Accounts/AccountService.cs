using DoubleCode.Application.Interfaces.Accounts;
using DoubleCode.Application.ViewModels.Accounts;
using DoubleCode.Domain.Entities.Users;
using DoubleCode.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.Application.Services.Accounts
{
    public class AccountService : IAccountService
    {
        #region Fields
        private readonly DoubleCodeContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        #endregion

        #region Ctor
        public AccountService(DoubleCodeContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager)

        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;


        }

        #endregion

        #region Methods
        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="vm"> UserRegister ViewModel </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the result
        /// </returns>
        public async Task<bool> RegisterAsync(RegisterAccountViewModel vm)
        {
            try
            {
                var user = new User()
                {
                    UserName = vm.UserName,
                    Email = vm.Email,
                    EmailConfirmed = true,
                    CreateDate=DateTime.Now,
                };
                var result = await _userManager.CreateAsync(user, vm.Password);
                    return true;
            }
            catch (Exception ex)
            {
                var m = ex.Message;
                return false;
            }
            
        }

        public async Task<bool> IsDuplicatedEmail(string email)
        {
            return await _context.Users.AnyAsync(c => c.Email == email);
        }

        public async Task<bool> IsDuplicatedUserName(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username);
        }

        #endregion
    }
}
