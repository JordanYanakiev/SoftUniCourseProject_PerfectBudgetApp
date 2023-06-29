using Microsoft.AspNetCore.Identity;
using PerfectBudgetApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectBudget.Data.Models
{
    public class DebtIssuer
    {
        [Required]
        public Guid DebtId { get; set; }
        [Required]
        [ForeignKey(nameof(DebtId))]
        public Debt Debt { get; set; } = null!;

        [Required]
        public string DebtIssuerId { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(DebtIssuerId))]
        public IdentityUser UserId { get; set; } = null!;
    }
}
