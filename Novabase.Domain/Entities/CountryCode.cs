using System.ComponentModel.DataAnnotations;

namespace Novabase.Domain.Entities
{
    public class CountryCode
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoAlpha2 { get; set; }
        public string IsoAlpha3 { get; set; }
        public int NumericCode { get; set; }
        public string Cctld { get; set; }

    }
}
