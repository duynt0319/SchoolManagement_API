using BusinessObjects.DataAccess;
using SchoolManagementDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRepository
{
    public class AccountRepository : IAccountRepository
    {
        private AccountDAO accountDAO;
        public AccountRepository()
        {
            accountDAO = new AccountDAO();
        }

        public Account GetAccountByEmail(string email)
        {
            return accountDAO.GetAccountByEmail(email);
        }

        public List<Account> GetAccounts()
        {
            return accountDAO.GetAccounts();
        }

        public bool AddAccount(Account account)
        {
            return accountDAO.AddAccount(account);
        }

        public bool RemoveAccount(string userName)
        {
           return accountDAO.DeleteAccount(userName);
        }

        public bool UpdateAccount(Account account)
        {
            return accountDAO.UpdateAccount(account);
        }
    }
}
