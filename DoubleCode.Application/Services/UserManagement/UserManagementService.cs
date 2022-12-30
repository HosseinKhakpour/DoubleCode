using DoubleCode.Application.Interfaces.IUserManagement;
using DoubleCode.Application.Statics;
using DoubleCode.Application.ViewModels.UserManagement;
using DoubleCode.Domain.Entities.Users;
using DoubleCode.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace DoubleCode.Application.Services.UserManagement
{
    public class UserManagementService : IUserManagementService
    {
        #region Fields
        private readonly DoubleCodeContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        #endregion

        #region Ctor
        public UserManagementService(DoubleCodeContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager)

        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;


        }

        #endregion

        public async Task<UserManagementCreateOrEditViewModel> FindAsync(string id)
        {

            var model = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
            return model.ToUserManagementCreateOrEditViewModel();
        }
        public async Task<UserManagementIndexViewModel> GetAllDeletedToShowAsync(int pageId = 1, string FilterEmail = "", string FilterUserName = "")
        {//Todo :list is not work appropriate 
            IEnumerable<UserManagementIndexViewModel> result = _context.Users.ToUserManagementIndexViewModel().IgnoreQueryFilters().Where(u => u.IsDelete);
            if (!string.IsNullOrEmpty(FilterEmail))
            {
                result = result.Where(u => u.Email.Contains(FilterEmail)).ToList();
            }

            if (!string.IsNullOrEmpty(FilterUserName))
            {
                result = result.Where(u => u.UserName.Contains(FilterUserName));
            }

            //take shows in each page
            int take = 20;
            int skip = (pageId - 1) * take;

            UserManagementIndexViewModel list = new UserManagementIndexViewModel();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            list.users = _context.Users.OrderBy(u => u.CreateDate).ToUserManagementIndexViewModel().Skip(skip).Take(take).ToList();
            return list;
        }
        public async Task<bool> AddAsync(UserManagementCreateOrEditViewModel vm)
        {
            try
            {
                var user = new User()
                {
                    UserName = vm.UserName,
                    Email = vm.Email,
                    EmailConfirmed = true,
                    CreateDate = DateTime.Now

                };
                var result = await _userManager.CreateAsync(user, vm.Password);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<bool> EditAsync(UserManagementCreateOrEditViewModel vm)
        {
            User user = await _context.Users.FindAsync(vm.Id);

            user.UserName = vm.UserName;
            if (!string.IsNullOrWhiteSpace(vm.Password))
            {
               await _userManager.ChangePasswordAsync(user,user.PasswordHash,vm.Password);
            }
            else
            {
                user.PasswordHash = user.PasswordHash;
            }

            var useremail = await _context.Users.SingleOrDefaultAsync(u => u.Email == vm.Email);
            if (useremail == null)
            {
                if (!string.IsNullOrWhiteSpace(vm.Email))
                {
                    user.Email =vm.Email;
                }
                else
                {
                    user.Email = user.Email;
                }
            }

            user.LastModifyDate = DateTime.Now;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            User user = await _context.Users.FindAsync(id);
            user.IsDeleted = true;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IPagedList<UserManagementIndexViewModel>> GetAllToShowAsync(int pageId = 1, string FilterEmail = "", string FilterUserName = "")
        {
            if (pageId <= 0) pageId = 1;
            IEnumerable<UserManagementIndexViewModel> result;
            result = _context.Users.ToUserManagementIndexViewModel();

            if (!string.IsNullOrEmpty(FilterEmail))
            {
                result = result.Where(u => u.Email.Contains(FilterEmail));
            }

            if (!string.IsNullOrEmpty(FilterUserName))
            {
                result = result.Where(u => u.UserName.Contains(FilterUserName));
            }

            return result
                .OrderByDescending(u => u.CreateDate)
                .ToPagedList(pageId, Values.PageSize);
        }
        public async Task<List<UserManagementIndexViewModel>> ShowDetail()
        {
            return await _context.Users.ToUserManagementIndexViewModel().ToListAsync();
        }
        public async Task<List<UserManagementIndexViewModel>> GetAllAsync()
        {
            IQueryable<UserManagementIndexViewModel> result = _context.Users.ToUserManagementIndexViewModel();
            return await result.ToListAsync();
        }

    } 
}
