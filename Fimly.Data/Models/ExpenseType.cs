﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Fimly.Data.Models
{
    public class ExpenseType
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string UserId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Please enter a shorter name.")]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Icon { get; set; }

        public ICollection<Expense> Expenses { get; set; }
    }
}
