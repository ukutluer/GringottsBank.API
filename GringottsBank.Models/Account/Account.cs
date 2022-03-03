using GringottsBank.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GringottsBank.Entities.Account
{
    public class Account : MongoDbEntity
    {
        public string UserId { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string AccountNumber { get; set; }
    }
}
