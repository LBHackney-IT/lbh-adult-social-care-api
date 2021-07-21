using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCare
{
    public class TransportEscortPackage : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TransportEscortPackageId { get; set; }
        public Guid DayCarePackageId { get; set; }
        public Guid ClientId { get; set; }
        public int? SupplierId { get; set; }
        public int? TransportEscortHoursPerWeek { get; set; }
        public decimal? TransportEscortCostPerWeek { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public string Destination { get; private set; }

        [ForeignKey(nameof(DayCarePackageId))]
        public DayCarePackage DayCarePackage { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }

        public TransportEscortPackage()
        {
            Destination = "Day Care Centre";
        }
    }
}
