using System;
using System.ComponentModel.DataAnnotations;

namespace Fimly.Data.Models
{
    public class Config
    {
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string UserId { get; set; }

        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
