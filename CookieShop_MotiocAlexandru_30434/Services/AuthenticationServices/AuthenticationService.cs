using CookieShop.Domain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookieShop.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IAccountService _dataService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService dataService, IPasswordHasher passwordHasher)
        {
            _dataService = dataService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Account> Login(string username, string password)
        {
            Account storedAccount = await _dataService.GetByUsername(username);
            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.AccountHolder.PasswordHash, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                return null;
            }
            return storedAccount;
        }

        public async Task<Account> Register(string email, string username, string password, string confirmPassword)
        {
            if(password != confirmPassword)
            {
                throw new Exception();
            }

            Account EmailAccount = await _dataService.GetByEmail(email);
            if(EmailAccount != null)
            {
                throw new Exception("email already exists");
            }

            Account userNamed = await _dataService.GetByUsername(username);
            if (userNamed != null)
            {
                throw new Exception("username already exists");
            }

            if (password == confirmPassword)
            {
                IPasswordHasher hasher = new PasswordHasher();
                string hashedPassword = hasher.HashPassword(password);

                User user = new User()
                {
                    Email = email,
                    Username = username,
                    PasswordHash = hashedPassword,
                    DateJoined = DateTime.Now

                };

                Account account = new Account()
                {
                    AccountHolder = user
                };

                return await _dataService.Create(account);
            }
            return null;
        }
    }
}
