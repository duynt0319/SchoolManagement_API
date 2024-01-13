using BusinessObjects.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService
{
    public interface IAccountService
    {
        public Account GetAccountByEmail(string email, string password);

        public Account GetAccountByEmail(string email);

        public List<Account> GetAccounts();

        public bool AddAccount(Account account);

        public bool RemoveAccount(string userName);

        public bool UpdateAccount(Account account); 
    }
}
