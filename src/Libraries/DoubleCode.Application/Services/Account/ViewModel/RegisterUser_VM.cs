﻿using DoubleCode.Application.Common.Utilities.AutoMapper;
using DoubleCode.Domain.Entity.User;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DoubleCode.Application.Services.Account.ViewModel;

public class RegisterUser_VM : IMapFrom<User>
{
    public long Id { get; set; }

    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    //[Remote("IsUserNameInUse", "Account", HttpMethod = "POST")]
    public string UserName { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
    //[Remote("IsEmailInUse", "Account", HttpMethod = "POST")]
    public string Email { get ; set; }

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string Password { get; set; }

    [Display(Name = "تکرار کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
    public string RePassword { get; set; }

    public bool IsEmailAtive { get; set; }

    public DateTime Created { get; set; }

}




