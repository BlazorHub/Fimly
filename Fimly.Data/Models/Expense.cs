using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fimly.Data.Models
{
    public class Expense
    {
        public Guid Id { get; set; }

        public Guid? PersonId { get; set; }
        public virtual Person Person { get; set; }

        [MaxLength(200)]
        public string UserId { get; set; }

        [Required]
        public Guid ExpenseTypeId { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "Please use a shorter name.")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Required]
        public decimal Cost { get; set; }

        public bool IsShared { get; set; }
        public bool IsRecurring { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateDue { get; set; }
    }
}
