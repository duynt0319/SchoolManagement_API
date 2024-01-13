using BusinessObjects.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementDAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;

        private static SchoolDbContext db = null;

        public AccountDAO()
        {
            db = new SchoolDbContext();
        }
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }
        public Account GetAccountByEmail(string email)
        {
            try
            {
                return db.Accounts.FirstOrDefault(m => m.Email.ToLower().Equals(email.ToLower()));
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting account by email", ex);
            }
        }
        public List<Account> GetAccounts()
        {
            try
            {
                var accounts = db.Accounts.ToList();
                return accounts;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting accounts", ex);
            }
        }

        public bool AddAccount(Account account)
        {
            var isSuccess = false;
            try
            {
                var checkDuplidcate = GetAccountByEmail(account.Email);
                if (account != null)
                {
                    if (checkDuplidcate == null)
                    {
                        db.Accounts.Add(account);
                        db.SaveChanges();
                        isSuccess = true;
                    }
                    return isSuccess;
                }
                return isSuccess;

            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding account", ex);
            }
            finally
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        public bool DeleteAccount(string userName)
        {
            var isSuccess = false;
            try
            {
                var accountToDelete = db.Accounts.FirstOrDefault(x => x.UserName.Equals(userName));

                if (accountToDelete != null)
                {
                    db.Accounts.Remove(accountToDelete);
                    db.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting an account", ex);
            }
        }

        public bool UpdateAccount(Account account)
        {
            var isSuccess = false;
            try
            {
                if (account != null)
                {
                    db.Accounts.Update(account);
                    db.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating an account", ex);
            }
        }
    }
}
