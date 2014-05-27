using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MyERP.DataAccess;

namespace MyERP.Web
{
    public class CustomMembershipProvider : MembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
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
            throw new NotImplementedException();
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
            using (var context = new EntitiesModel())
            {
                var user = context.Users.FirstOrDefault(u => u.Name == username);
                return new MyERPMembershipUser("myCustomProvider", user.Name, user.Id, user.Email, user.PasswordQuestion,
                    user.Comment, user.IsActivated, user.IsLockedOut, user.CreatedDate, user.LastLoginDate,
                    user.LastLoginDate, user.LastModifiedDate, user.LastLockedOutDate, user.ClientId);
            }
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            using (var context = new EntitiesModel())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == (Guid)providerUserKey);
                return new MyERPMembershipUser("myCustomProvider", user.Name, user.Id, user.Email, user.PasswordQuestion,
                    user.Comment, user.IsActivated, user.IsLockedOut, user.CreatedDate, user.LastLoginDate,
                    user.LastLoginDate, user.LastModifiedDate, user.LastLockedOutDate, user.ClientId);
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