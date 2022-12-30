using DoubleCode.Application.ViewModels.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace DoubleCode.Application.Interfaces.IUserManagement
{
    public interface IUserManagementService
    {
        Task<bool> DeleteAsync(string id);
        Task<UserManagementCreateOrEditViewModel> FindAsync(string id);
        Task<IPagedList<UserManagementIndexViewModel>> GetAllToShowAsync(int pageId = 1, string FilterEmail = "", string FilterUserName = "");
        Task<List<UserManagementIndexViewModel>> ShowDetail();
        Task<UserManagementIndexViewModel> GetAllDeletedToShowAsync(int pageId = 1, string FilterEmail = "", string FilterUserName = "");
        Task<bool> AddAsync(UserManagementCreateOrEditViewModel vm);
        Task<bool> EditAsync(UserManagementCreateOrEditViewModel vm);
    }
}
