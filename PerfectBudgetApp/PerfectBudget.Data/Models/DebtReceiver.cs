using Microsoft.AspNetCore.Identity;
using PerfectBudgetApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectBudget.Data.Models
{
    public class DebtReceiver
    {
        [Required]
        public Guid DebtId { get; set; }
        [Required]
        [ForeignKey(nameof(DebtId))]
        public Debt Debt { get; set; } = null!;

        [Required]
        public string DebtReceiverId { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(DebtReceiverId))]
        public IdentityUser UserId { get; set; } = null!;
    }
}
