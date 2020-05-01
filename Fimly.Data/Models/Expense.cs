using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fimly.Data.Models
{
    public class Expense
    {
        public Guid Id { get; set; }

        public Guid? PersonId { get; set; } = null;
        public virtual Person Person { get; set; }

        [MaxLength(200)]
        public string UserId { get; set; }

        public Guid ExpenseTypeId { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "Please use a shorter name.")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        [Range(1, 100000000, ErrorMessage = "Please enter a cost larger than 0.")]
        public decimal Cost { get; set; }

        public bool IsRecurring { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateDue { get; set; }

        [MaxLength(50)]
        public string Icon { get; set; }
    }
}
