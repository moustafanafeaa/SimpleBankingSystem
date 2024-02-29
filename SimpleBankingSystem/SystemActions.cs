using Microsoft.EntityFrameworkCore;
using SimpleBankingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankingSystem
{
    internal class SystemActions : ICreateAccount, IDeleteAccount
    {
        private readonly ApplicationDbContext _context;
        public SystemActions(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateAccount(int accountNumber, string OwnerName, double initialBalance = 0)
        {

            var isvalid = _context.BankAccounts.FirstOrDefault(x => x.Accountnumber == accountNumber);
            if (isvalid == null)
            {
                var account = new BankAccount
                {
                    Balance = initialBalance,
                    Accountnumber = accountNumber,
                    OwnerName = OwnerName,
                };
                _context.BankAccounts.Add(account);
                _context.SaveChanges();
            }
        }

        public void DeleteAccount(int accountNumber)
        {
            var accont = _context.BankAccounts.FirstOrDefault(x => x.Accountnumber == accountNumber);
            if (accont == null)
            {
                throw new ArgumentException("Account not found");
            }
            else
            {
                _context.BankAccounts.Remove(accont);
                _context.SaveChanges();
            }
        }
    }
}
