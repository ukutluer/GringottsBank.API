﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GringottsBank.Entities.AccountTransaction
{
    public class UserAccountTransactionRequest
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
