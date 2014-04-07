// Authentication.cs
// Copied from RIA Services Essentials on CodePlex http://riaservices.codeplex.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace System.ServiceModel.DomainServices.Server.ApplicationServices {

    /// <summary>
    /// A set of utility methods around the authentication scenario.
    /// </summary>
    public static class Authentication {

        private const int PasswordSaltSize = 8;
        private const int PasswordSaltLength = 12;      // Accounts for base64 overhead

        internal static UserBase GetUser(Type authServiceType, DomainServiceContext context) {
            UserBase user = null;

            DomainService authService =
                DomainService.Factory.CreateDomainService(authServiceType, context);

            if (authService != null) {
                try {
                    DomainServiceDescription serviceDescription = DomainServiceDescription.GetDescription(authServiceType);
                    DomainOperationEntry queryOperation = serviceDescription.GetQueryMethod("GetUser");

                    QueryDescription query = new QueryDescription(queryOperation);
                    IEnumerable<ValidationResult> validationErrors;
                    int totalCount;

                    IEnumerable queryResult = authService.Query(query, out validationErrors, out totalCount);
                    if ((validationErrors != null) && validationErrors.Any()) {
                        throw new InvalidOperationException(validationErrors.First().ErrorMessage);
                    }

                    if (queryResult != null) {
                        user = queryResult.OfType<UserBase>().FirstOrDefault();
                    }
                }
                finally {
                    DomainService.Factory.ReleaseDomainService(authService);
                }
            }

            return user;
        }

        /// <summary>
        /// Gets the current user object using a RIA Services Authentication service.
        /// </summary>
        /// <typeparam name="TUser">The type of the User object in use within the application.</typeparam>
        /// <typeparam name="TAuthenticationService">The type of the Authentication service implementation in the application.</typeparam>
        /// <param name="context">The DomainServiceContext that provides access to services.</param>
        /// <returns>The user object if one can be created successfully; null otherwise.</returns>
        public static TUser GetUser<TUser, TAuthenticationService>(DomainServiceContext context) where TAuthenticationService : DomainService, IAuthentication<TUser> where TUser : UserBase {
            DomainServiceContext authServiceContext =
                new DomainServiceContext(context, DomainOperationType.Query);
            return (TUser)GetUser(typeof(TAuthenticationService), authServiceContext);
        }

        /// <summary>
        /// Hashes the specified password using a random password salt generated within the method.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hash value of the password.</returns>
        public static string HashPassword(string password) {
            if (String.IsNullOrEmpty(password)) {
                throw new ArgumentNullException("password");
            }

            // First generate a password salt using a cryptographic random number
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            byte[] buffer = new byte[PasswordSaltSize];
            rng.GetBytes(buffer);

            string passwordSalt = Convert.ToBase64String(buffer);
            Debug.Assert(passwordSalt.Length == PasswordSaltLength);

            // Perform the hash of the password along with the generated salt
            return HashPassword(password, passwordSalt);
        }

        private static string HashPassword(string password, string passwordSalt) {
            string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(password + passwordSalt, "SHA1");

            // Embed the salt into the hash, so we can retrieve it later when validating
            // passwords.
            return hash + passwordSalt;
        }

        /// <summary>
        /// Validates the specified password by comparing with to a previously computed hash value.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <param name="storedPasswordHash">The previously computed password hash to compare against.</param>
        /// <returns>true if the password is valid; false otherwise.</returns>
        public static bool ValidatePassword(string password, string storedPasswordHash) {
            if (String.IsNullOrEmpty(password)) {
                throw new ArgumentNullException("password");
            }
            if (String.IsNullOrEmpty(storedPasswordHash)) {
                throw new ArgumentNullException("storedPasswordHash");
            }

            // Extract the random password salt that was generated.
            string passwordSalt = storedPasswordHash.Substring(storedPasswordHash.Length - PasswordSaltLength);

            // Now take the password that is to be validated and hash it with the same salt,
            // and compare the two hashes.
            string passwordHash = HashPassword(password, passwordSalt);

            return (String.CompareOrdinal(passwordHash, storedPasswordHash) == 0);
        }
    }
}
