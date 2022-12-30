using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.Application.ViewModels.UserManagement
{
    public class UserManagementIndexViewModel
    {
        public string Id { get; set; }
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsDelete { get; set; }
        public int PageCount { get; set; }
        [Display(Name = "صحفه فعلی")]
        public int CurrentPage { get; set; }
        public List<UserManagementIndexViewModel> users { get; set; }

    }
}
