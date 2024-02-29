using SimpleBankingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Transaction = SimpleBankingSystem.Models.Transaction;

namespace SimpleBankingSystem
{
	internal class Actions : IDeposting, IwithDrawing, IBalance,IGetTransactionHistory
	{

		private readonly ApplicationDbContext _context;

		public Actions(ApplicationDbContext context)
		{
			_context = context;
		}
		public void Deposting(int accountNumber, double amount)
		{
			var account = _context.BankAccounts.FirstOrDefault(y=>y.Accountnumber == accountNumber);
			if(account == null )
				throw new ArgumentException("Account not found");
			if (amount < 0)
				throw new ArgumentException("the amount must be greater than 0");
			else
			{
				account.Balance += amount;
				var transaction = new Transaction
				{
					DateTime = DateTime.Now,
					Amount = amount,
					BankAccountId = account.Id
				};
				_context.Transactions.Add(transaction);
				_context.SaveChanges();

			}

        }

		public void WithDrawing(int accountNumber, double amount)
		{
			var account = _context.BankAccounts.FirstOrDefault(y => y.Accountnumber == accountNumber);
			if (account != null)
			{
				if (account.Balance >= amount)
				{
					account.Balance -= amount;
					var transaction = new Transaction { DateTime = DateTime.Now, Amount = amount, BankAccountId = account.Id };
					_context.Transactions.Add(transaction);
					_context.SaveChanges();
				}
				else
				{
					throw new InvalidOperationException("Insufficient funds.");
				}

			}
			else { throw new ArgumentException("Account not found."); }
		}

		public double CheckBalance(int accountNumber)
		{
			var accont = _context.BankAccounts.FirstOrDefault(x => x.Accountnumber == accountNumber);
			if (accont == null)
			{
				throw new ArgumentException("Account not found");
			}
			return accont.Balance;
		}
	

		public List<Transaction> GetTransactionHistory(int accountNumber)
		{
			var account = _context.BankAccounts.FirstOrDefault(x=>x.Accountnumber == accountNumber);
			if(account!= null)
			{
				return account.transactions.OrderByDescending(t=>t.DateTime).ToList();
			}
			else
			{
				throw new ArgumentException("Account not found.");
			}
		}
	}
}
