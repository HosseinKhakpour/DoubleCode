using DoubleCode.Application.ViewModels.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.Application.Interfaces.Accounts
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(RegisterAccountViewModel vm);
        Task<bool> IsDuplicatedEmail(string email);
        Task<bool> IsDuplicatedUserName(string username);

    }
}
