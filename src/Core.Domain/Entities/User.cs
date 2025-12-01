using Core.Domain.Common;
using System.Collections.Generic;

namespace Core.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public decimal CurrentBalance { get; private set; }

        // Navigation properties
        public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();
        public ICollection<FinancialRule> FinancialRules { get; private set; } = new List<FinancialRule>();

        private User() { } // For EF Core

        public User(string name, string email, string phoneNumber, decimal initialBalance = 0)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            CurrentBalance = initialBalance;
        }

        public void UpdateBalance(decimal amount)
        {
            CurrentBalance += amount;
            UpdateTimestamp();
        }
    }
}
