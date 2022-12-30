using DoubleCode.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.Application.ViewModels.UserManagement
{
    public static class UserManagementConvertor
    {
        #region CreateOrEdit
        public static UserManagementCreateOrEditViewModel ToUserManagementCreateOrEditViewModel(this User user)
        {
            return new UserManagementCreateOrEditViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.PasswordHash,
                CreateDate = user.CreateDate,
                IsDelete = user.IsDeleted,
            };
        }

        public static IQueryable<UserManagementCreateOrEditViewModel> ToUserManagementCreateOrEditViewModel(this IQueryable<User> users)
        {
            return users.Select(u => u.ToUserManagementCreateOrEditViewModel());
        }
        #endregion

        #region Index
        public static UserManagementIndexViewModel ToUserManagementIndexViewModel(this User user)
        {
            if (user == null) return null;
            return new UserManagementIndexViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                Id = user.Id,
                CreateDate=user.CreateDate,
                IsDelete=user.IsDeleted,
            };
        }

        public static IQueryable<UserManagementIndexViewModel> ToUserManagementIndexViewModel(
            this IQueryable<User> users)
        {
            return users.Select(u => u.ToUserManagementIndexViewModel());
        }

        public static IEnumerable<UserManagementIndexViewModel> ToUserManagementIndexViewModel(this IEnumerable<User> users)
        {
            return users.Select(u => u.ToUserManagementIndexViewModel());
        }
        #endregion

    }
}
