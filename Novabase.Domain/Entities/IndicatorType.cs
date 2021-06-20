using System;
using System.ComponentModel.DataAnnotations;

namespace Novabase.Domain.Entities
{
    public class IndicatorType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Initials { get; set; }
    }
}
