using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fimly.Data.Models
{
    public class Currency
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        public string Symbol { get; set; }

        [Required]
        [MaxLength(5)]
        public string Name { get; set; }

        public virtual ICollection<Config> Configs { get; set; }
    }
}
