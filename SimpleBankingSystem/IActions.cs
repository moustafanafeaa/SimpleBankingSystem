using SimpleBankingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankingSystem
{
	internal interface IActions
	{
		
	}
	public interface IDeposting
	{
		void Deposting(int accountNumber, double Price);
	}
	public interface IwithDrawing
	{ 
			void WithDrawing(int accountNumber,double Price);
	}
	public interface IBalance 
	{
		double CheckBalance(int accountNumber);
	}

	public interface ICreateAccount
	{
		void CreateAccount(int accountNumber,string OwnerName,double initialBalance = 0);
	}
	public interface IDeleteAccount 
	{
		void DeleteAccount(int accountNumber);
	}
	public interface IGetTransactionHistory 
	{
		List<Transaction> GetTransactionHistory(int accountNumber);
	}
}
