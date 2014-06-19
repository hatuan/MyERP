using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

            using (EntitiesModel context = new EntitiesModel())
            {
                try
                {
                    var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
                    return user != null;
                }
                catch (Exception)
                {
                    return false;
                }
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

                user = context.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    status = MembershipCreateStatus.DuplicateEmail;
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
                    ClientId = null,
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
                    OrganizationId = null,
                    Password = password,
                    PasswordAnswer = passwordAnswer,
                    PasswordQuestion = passwordQuestion
                };
                try
                {
                    context.Add(user);
                    context.SaveChanges();
                    status = MembershipCreateStatus.Success;

                    return new MyERPMembershipUser("myCustomProvider", user.Name, user.Id, user.Email, user.PasswordQuestion,
                        user.Comment, user.IsActivated, user.IsLockedOut, user.CreatedDate, user.LastLoginDate,
                        user.LastLoginDate, user.LastModifiedDate, user.LastLockedOutDate, user.ClientId);
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
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var cacheKey = string.Format("UserData_{0}", username);
            if (HttpRuntime.Cache[cacheKey] != null)
                return (MyERPMembershipUser)HttpRuntime.Cache[cacheKey];

            using (var context = new EntitiesModel())
            {
                var user = context.Users.FirstOrDefault(u => u.Name == username);
                if (user != null)
                {
                    var membershipUser = new MyERPMembershipUser(user);
                    
                    //Store in cache
                    HttpRuntime.Cache.Insert(cacheKey, membershipUser, null, DateTime.Now.AddMinutes(_cacheTimeoutInMinutes), Cache.NoSlidingExpiration);

                    return new MyERPMembershipUser("myCustomProvider", user.Name, user.Id, user.Email,
                        user.PasswordQuestion,
                        user.Comment, user.IsActivated, user.IsLockedOut, user.CreatedDate, user.LastLoginDate,
                        user.LastLoginDate, user.LastModifiedDate, user.LastLockedOutDate, user.ClientId);
                }
                else
                    return null;

            }
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            using (var context = new EntitiesModel())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == (Guid)providerUserKey);
                if(user != null)
                    return new MyERPMembershipUser("myCustomProvider", user.Name, user.Id, user.Email, user.PasswordQuestion,
                        user.Comment, user.IsActivated, user.IsLockedOut, user.CreatedDate, user.LastLoginDate,
                        user.LastLoginDate, user.LastModifiedDate, user.LastLockedOutDate, user.ClientId);
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
            get { throw new NotImplementedException(); }
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
        public Guid? ClientId { get; set; }

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
            lastPasswordChangedDate:user.LastModifiedDate,
            lastLockoutDate:user.LastLockedOutDate)
        {
            ClientId = user.ClientId ?? Guid.Empty;
        }

        public MyERPMembershipUser(string providername,
                                  string username,
                                  object providerUserKey,
                                  string email,
                                  string passwordQuestion,
                                  string comment,
                                  bool isApproved,
                                  bool isLockedOut,
                                  DateTime creationDate,
                                  DateTime lastLoginDate,
                                  DateTime lastActivityDate,
                                  DateTime lastPasswordChangedDate,
                                  DateTime lastLockedOutDate,
                                  Guid? clientId) :
                                  base(providername,
                                       username,
                                       providerUserKey,
                                       email,
                                       passwordQuestion,
                                       comment,
                                       isApproved,
                                       isLockedOut,
                                       creationDate,
                                       lastLoginDate,
                                       lastActivityDate,
                                       lastPasswordChangedDate,
                                       lastLockedOutDate)
        {
            this.ClientId = clientId ?? Guid.Empty;
        }

    }
}