using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankingSystem.Models
{
	public class BankAccount
	{
		
			public int Id { get; set; }

			[MinLength(3)]
		
			public int Accountnumber { get; set; }

			[MaxLength(100)]
			public string OwnerName { get; set; }
		
			public double Balance { get; set; }
			public List<Transaction> transactions { get; set; }
		
	}
}
