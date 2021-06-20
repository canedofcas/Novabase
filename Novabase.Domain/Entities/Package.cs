using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novabase.Domain.Entities
{
    public class Package 
    {
        [Key]
        public int Id { get; private set; }

        public bool HasValueToPay { get; private set; }
        public string TrackingCode { get; private set; }
        public int CodeArea { get; private set; }
        public string Description { get; private set; }
        public double Weight { get; private set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; private set; }
        public DateTime ReceiveDate { get; private set; }

        public virtual IEnumerable<Checkpoint> Checkpoints { get; set; }

        [Required]
        public int IdSize { get; private set; }
        [ForeignKey("IdSize")]
        public virtual Indicator Size { get; private set; }
        
        public Package(){}

        public Package(bool hasValueToPay, int codeArea, string description, double weight, decimal price, int idSize)
        {
            HasValueToPay = hasValueToPay;
            CodeArea = codeArea;
            Description = description;
            Weight = weight;
            Price = price;
            IdSize = idSize;
            ReceiveDate = DateTime.Now;
        }

        public Package(int id, bool hasValueToPay, int codeArea, string description, double weight, decimal price, int idSize)
        {
            Id = id;
            HasValueToPay = hasValueToPay;
            CodeArea = codeArea;
            Description = description;
            Weight = weight;
            Price = price;
            IdSize = idSize;
        }

        public void GetTrackingCode(string code)
        {
            TrackingCode = code;

        }

    }
}
