using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common
{
    public class CarePackageHistory : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid CarePackageId { get; set; }
        public string Description { get; set; }
        public string RequestMoreInformation { get; set; }
        public int StatusId { get; set; }
        [ForeignKey(nameof(CarePackageId))] public CarePackage CarePackage { get; set; }
    }
}
