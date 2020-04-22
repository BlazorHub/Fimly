using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fimly.Data.Models
{
    public class Person
    {
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [MaxLength(25, ErrorMessage = "Please use a shorter name.")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Monthly Income")]
        public decimal Income { get; set; }

        public bool IsSharedPerson { get; set; }

        public ICollection<Expense> Expenses { get; set; }
    }
}
