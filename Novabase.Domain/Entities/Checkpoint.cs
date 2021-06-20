using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novabase.Domain.Entities
{
    public class Checkpoint
    {
        public Checkpoint( string country, string city, int idPackage,int idStatus, int idTypeControl, int idPlaceType)
        {
            Country = country;
            City = city;
            IdPackage = idPackage;
            IdStatus = idStatus;
            IdTypeControl = idTypeControl;
            IdPlaceType = idPlaceType;
            InteractionDate = DateTime.Now;
        }

        public Checkpoint(int id, string country, string city, int idPackage, int idStatus, int idTypeControl, int idPlaceType)
        {
            Id = id;
            Country = country;
            City = city;
            IdPackage = idPackage;
            IdStatus = idStatus;
            IdTypeControl = idTypeControl;
            IdPlaceType = idPlaceType;
            InteractionDate = DateTime.Now;
        }

        public Checkpoint() {}

        [Key]
        public int Id { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
        public DateTime InteractionDate { get; set; }

        ///////
        public int IdPackage { get; private set; }
        [ForeignKey("IdPackage")]
        public virtual Package Package { get; set; }

        ///////
        public int IdTypeControl { get; private set; }

        [ForeignKey("IdTypeControl")]
        public virtual Indicator TypeControl { get;  set; }

        public int IdStatus { get; private set; }

        [ForeignKey("IdStatus")]
        public virtual Indicator Status { get; set; }

        /////
        [ForeignKey("IdPlaceType")]
        public virtual Indicator Placetype { get; set; }
        public int IdPlaceType { get; private set; }

        
    }
}
