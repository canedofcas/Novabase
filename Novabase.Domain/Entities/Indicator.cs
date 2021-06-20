using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novabase.Domain.Entities
{
    public class Indicator 
    {
        [Key]
        public int Id { get; private set; }
        public int Value { get; private set; }
        public string Name { get; private set; }
        public string Initial { get; private set; }
        public string Description { get; private set; }
        public int IdIndicatorType { get; private set; }
        [ForeignKey("IdIndicatorType")]
        public virtual IndicatorType IndicatorType { get; set; }
       
        public Indicator(int value, int idIndicatorType, string name, string initial, string description)
        {
            Value = value;
            Name = name;
            IdIndicatorType = idIndicatorType;
            Initial = initial;
            Description = description;

        }
        public Indicator()
        {

        }
    }
}
