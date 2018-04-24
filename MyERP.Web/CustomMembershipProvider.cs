using System;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using MyERP.DataAccess;

namespace MyERP.Web
{
    public class CustomMembershipProvider : MembershipProvider
    {
        private int _cacheTimeoutInMinutes = 30;

        /// <summary>
        /// Initialize values from web.config.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        public override void Initialize(string name, NameValueCollection config)
        {
            // Set Properties
            int val;
            if (!string.IsNullOrEmpty(config["cacheTimeoutInMinutes"]) && Int32.TryParse(config["cacheTimeoutInMinutes"], out val))
                _cacheTimeoutInMinutes = val;

            // Call base method
            base.Initialize(name, config);
        }

        public override bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            var context = new EntitiesModel();
            try
            {
                var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
                return user != null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override string ApplicationName
        {
            get { return "MyERP"; }
            set { }
        }


        // Other overrides not implemented
        #region Other overrides not implemented

        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey,
            out MembershipCreateStatus status)
        {
            using (var context = new EntitiesModel())
            {
                var user = context.Users.FirstOrDefault(u => u.Name == username);
                if (user != null)
                {
                    status = MembershipCreateStatus.DuplicateUserName;
                    return null;
                }
                
                user = context.Users.FirstOrDefault(u => u.Id.CompareTo(providerUserKey) == 0);
                if (user != null)
                {
                    status = MembershipCreateStatus.DuplicateProviderUserKey;
                    return null;
                }

                user = new User()
                {
                    ClientId = 0,
                    Comment = "",
                    CreatedDate = DateTime.Now,
                    Email = email,
                    FullName = "",
                    IsActivated = true,
                    IsLockedOut = false,
                    Name = username,
                    LastLockedOutDate = DateTime.MinValue,
                    LastLockedOutReason = "",
                    LastLoginDate = DateTime.Now,
                    LastLoginIp = "0.0.0.0",
                    LastModifiedDate = DateTime.Now,
                    OrganizationId = 0,
                    Password = password,
                    PasswordAnswer = passwordAnswer,
                    PasswordQuestion = passwordQuestion,
                    CultureUiId = "vi-VN"
                };
                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    status = MembershipCreateStatus.Success;

                    return new MyERPMembershipUser(user);
                }
                catch (Exception)
                {
                    status = MembershipCreateStatus.ProviderError;
                    return null;
                }
                

            }

        }
        
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            using (var context = new EntitiesModel())
            {
                var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == oldPassword);
                if (user == null)
                {
                    return false;
                }

                try
                {
                    user.Password = newPassword;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            using (var context = new EntitiesModel())
            {
                var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
                if (user == null)
                {
                    return false;
                }

                try
                {
                    user.PasswordQuestion = newPasswordQuestion;
                    user.PasswordAnswer = newPasswordAnswer;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            using (var context = new EntitiesModel())
            {
                var user = context.Users.FirstOrDefault(u => u.Name == username && u.PasswordAnswer == answer);
                return user != null ? user.Password : null;
            }
        }
        
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            //Get MyERPMembershipUser from Cache if found
            var cacheKey = string.Format("UserData_{0}", username);
            if (HttpRuntime.Cache[cacheKey] != null)
                return (MyERPMembershipUser)HttpRuntime.Cache[cacheKey];

            using (var context = new EntitiesModel())
            {
                var user = context.Users.Include("Client").Include("Organization")
                    .FirstOrDefault(u => u.Name == username);
                if (user != null)
                {
                    var membershipUser = new MyERPMembershipUser(user);
                    
                    //Store in cache
                    HttpRuntime.Cache.Insert(cacheKey, membershipUser, null, DateTime.Now.AddMinutes(_cacheTimeoutInMinutes), Cache.NoSlidingExpiration);

                    return membershipUser;
                }
                else
                    return null;

            }
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            var cacheKey = string.Format("UserData_{0}", providerUserKey);
            if (HttpRuntime.Cache[cacheKey] != null)
                return (MyERPMembershipUser) HttpRuntime.Cache[cacheKey];

            using (var context = new EntitiesModel())
            {
                var user = context.Users.Include("Client").Include("Organization").FirstOrDefault(u => u.Id == (long)providerUserKey);
                if (user != null)
                {
                    var membershipUser = new MyERPMembershipUser(user);
                    //Store in cache
                    HttpRuntime.Cache.Insert(cacheKey, membershipUser, null, DateTime.Now.AddMinutes(_cacheTimeoutInMinutes), Cache.NoSlidingExpiration);

                    return membershipUser;
                }
                else
                    return null;

            }
        }

        public override string GetUserNameByEmail(string email)
        {
            using (var context = new EntitiesModel())
            {
                var user = context.Users.FirstOrDefault(u => u.Email == email);
                return user.Name;
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { return false; }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
        #endregion

    }

    public class MyERPMembershipUser : MembershipUser
    {
        public Client Client { get; set; }
        public long ClientId { get; set; }
        public long OrganizationId { get; set; }
        public String CultureUiId { get; set; }

        public Organization Organization { get; set; }
        public string FullName { get; set; }

        public MyERPMembershipUser(User user) : base(providerName: "myCustomProvider",
            name:user.Name,
            providerUserKey:user.Id,
            email:user.Email,
            passwordQuestion:user.PasswordQuestion,
            comment:user.Comment,
            isApproved:user.IsActivated,
            isLockedOut:user.IsLockedOut,
            creationDate:user.CreatedDate,
            lastLoginDate:user.LastLoginDate,
            lastActivityDate:user.LastLoginDate,
            lastPasswordChangedDate:user.LastPasswordChangedDate,
            lastLockoutDate:user.LastLockedOutDate)
        {
            Client = user.Client;
            ClientId = user.ClientId ;
            
            Organization = user.Organization;
            OrganizationId = user.OrganizationId;
            
            FullName = user.FullName;

            CultureUiId = user.CultureUiId;
        }

        //public MyERPMembershipUser(string providername,
        //                          string username,
        //                          object providerUserKey,
        //                          string email,
        //                          string passwordQuestion,
        //                          string comment,
        //                          bool isApproved,
        //                          bool isLockedOut,
        //                          DateTime creationDate,
        //                          DateTime lastLoginDate,
        //                          DateTime lastActivityDate,
        //                          DateTime lastPasswordChangedDate,
        //                          DateTime lastLockedOutDate,
        //                          Guid? clientId) :
        //                          base(providername,
        //                               username,
        //                               providerUserKey,
        //                               email,
        //                               passwordQuestion,
        //                               comment,
        //                               isApproved,
        //                               isLockedOut,
        //                               creationDate,
        //                               lastLoginDate,
        //                               lastActivityDate,
        //                               lastPasswordChangedDate,
        //                               lastLockedOutDate)
        //{
        //    this.ClientId = clientId ?? Guid.Empty;
        //}


        public override string GetPassword(string passwordAnswer)
        {
            using (var context = new EntitiesModel())
            {
                var user = context.Users.FirstOrDefault(u => u.Name == this.UserName && u.PasswordAnswer == passwordAnswer);
                return user != null ? user.Password : null;
            }
        }

        public override string GetPassword()
        {
            using (var context = new EntitiesModel())
            {
                var user = context.Users.FirstOrDefault(u => u.Name == this.UserName);
                return user != null ? user.Password : null;
            }
        }
    }
}