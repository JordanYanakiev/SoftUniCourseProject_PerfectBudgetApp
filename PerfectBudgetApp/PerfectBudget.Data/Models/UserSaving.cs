using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectBudget.Data.Models
{
    public class UserSaving
    {
        [Required]
        public Guid SavingsId { get; set; }
        [Required]
        [ForeignKey(nameof(SavingsId))]
        public Saving Saving { get; set; }

        [Required]
        public string UserId { get; set; }
        [Required]
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
    }
}
