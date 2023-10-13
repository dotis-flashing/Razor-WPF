﻿using System;
using System.Collections.Generic;

namespace BusinessObjects.Entity
{
    public partial class Customer
    {
        public Customer()
        {
            RentingTransactions = new HashSet<RentingTransaction>();
        }

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Telephone { get; set; }
        public string Email { get; set; } = null!;
        public DateTime? CustomerBirthday { get; set; }
        public string CustomerStatus { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<RentingTransaction> RentingTransactions { get; set; }
    }
}
