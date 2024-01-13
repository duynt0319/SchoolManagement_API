using BusinessObjects.DataAccess;
using SchoolManagementDAO;
using SchoolRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool AddAccount(Account account)
        {
            return _accountRepository.AddAccount(account);
        }

        public Account GetAccountByEmail(string email, string password)
        {
            var account = GetAccountByEmail(email);
            if (account != null && account.Password.Equals(password))
            {
                return account;
            }
            return null;
        }

        public Account GetAccountByEmail(string email)
        {
           return _accountRepository.GetAccountByEmail(email);
        }

        public List<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public bool RemoveAccount(string userName)
        {
            return _accountRepository.RemoveAccount(userName);
        }

        public bool UpdateAccount(Account account)
        {
            return _accountRepository.UpdateAccount(account);
        }
    }
}
