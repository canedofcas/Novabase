using System;

namespace Novabase.Domain.Queries
{
    public class PackageQueryResult
    {
        public int Id { get; set; }
        public int  CodeArea { get; set; }
        public string TrackingCode { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Size { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime InteractionDate { get; set; }
    }
}
