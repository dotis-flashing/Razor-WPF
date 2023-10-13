using System;
using System.Collections.Generic;

namespace BusinessObjects.Entity
{
    public partial class RentingTransaction
    {
        public RentingTransaction()
        {
            RentingDetails = new HashSet<RentingDetail>();
        }

        public int RentingTransationId { get; set; }
        public DateTime? RentingDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public string RentingStatus { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<RentingDetail> RentingDetails { get; set; }
    }
}
