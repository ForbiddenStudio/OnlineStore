﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using OnlineStoreDomain;

namespace OnlineStoreRepository.App
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        { }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,
             IOwinContext context)
        {
            //Store db = context.Get<Store>();
            //AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));


            //manager.PasswordValidator = new CustomPasswordValidator
            //{
            //    RequiredLength = 6,
            //    RequireNonLetterOrDigit = false,
            //    RequireDigit = false,
            //    RequireLowercase = true,
            //    RequireUppercase = true
            //};
            //manager.UserValidator = new CustomUserValidator(manager)
            //{
            //    AllowOnlyAlphanumericUserNames = true,
            //    RequireUniqueEmail = true
            //};
            //return manager;
            Store db = context.Get<Store>();
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));
            //manager.PasswordValidator = new CustomPasswordValidator
            //{
            //    RequiredLength = 6,
            //    RequireNonLetterOrDigit = false,
            //    RequireDigit = false,
            //    RequireLowercase = true,
            //    RequireUppercase = true
            //};
            //  manager.UserValidator = new CustomEmailValidator();
            return manager;
        }
    }
}