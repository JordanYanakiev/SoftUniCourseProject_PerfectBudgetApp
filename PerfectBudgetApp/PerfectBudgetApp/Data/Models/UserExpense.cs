﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectBudgetApp.Data.Models
{
    public class UserExpense
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        [Required]
        public int ExpenseId { get; set; }
        [Required]
        [ForeignKey(nameof(ExpenseId))]
        public Expense Expense { get; set; }
    }
}
