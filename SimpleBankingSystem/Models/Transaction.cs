using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankingSystem.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public double Amount { get; set; }
        public int BankAccountId { get; set; }
        public BankAccount BankAccount {  set; get; }
    }
}
