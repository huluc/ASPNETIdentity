using ASPNETIdentity.Exceptions;
using ASPNETIdentity.Identity;
using ASPNETIdentity.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ASPNETIdentity.Services
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class UserService : UserManager<User, int>
    {
        public static UserService Obj { get; private set; }

        static IIdentityUserRepository _identityUserRepository;
        static SqlServerRepository _serverRepository;
        static UserService() //Dependency Injection
        {
            IIdentityUserRepository store = new IdentityUserRepository();
            Obj = new UserService(store);

            _identityUserRepository = new IdentityUserRepository();
            _serverRepository = new SqlServerRepository();
        }
        public UserService(IIdentityUserRepository store)
            : base(store)
        {
            _identityUserRepository = store;
        }

        public static UserService Create(IdentityFactoryOptions<UserService> options, IOwinContext context)
        {
            var manager = new UserService(new IdentityUserRepository());
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = false;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            //manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            //{
            //    MessageFormat = "Your security code is {0}"
            //});
            //manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            //{
            //    Subject = "Security Code",
            //    BodyFormat = "Your security code is {0}"
            //});
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public void Create(User user, string password)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "must not be null.");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password), "must not be null.");
            if (user.IsUsedEmail())
                throw new BusinessRuleException(nameof(user), BusinessRules.UsedEmail);
            // https://stackoverflow.com/questions/45725544/usermanager-createasync-success-always-returns-false
            IdentityResult result = TaskUtil.Await(() => CreateAsync(user, password));//Burada kullanıcı rolü rol tablosuna farklı bir id ile tekrar ekleniyor!!!
            if (result.Succeeded)
            {
                var userResult = _identityUserRepository.FindByNameAsync(user.UserName);
                
            }
            else
            {
                var errors = result.Errors;
                var message = string.Join(", ", errors);              
            }
          
        }
        public User FindByName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName), "must not be null or empty.");
            return _serverRepository.Get<User>(x => x.UserName == userName);
        }
        public List<User> GetUsers()
        {
            return _serverRepository.GetAll<User>();
        }
    }
}