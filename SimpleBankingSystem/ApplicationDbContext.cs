using Microsoft.EntityFrameworkCore;
using SimpleBankingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankingSystem
{
	internal class ApplicationDbContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog = BankingSystem;Integrated Security=True;TrustServerCertificate=True");
		}
		public DbSet<BankAccount> BankAccounts { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
	}
}
