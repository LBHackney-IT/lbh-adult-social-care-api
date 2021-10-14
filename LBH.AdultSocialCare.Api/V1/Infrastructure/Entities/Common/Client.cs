using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common
{
    //TODO FK: change name to ServiceUser after code clean up
    [GenerateMappingFor(typeof(ServiceUserBasicDomain))]
    public class Client : BaseEntity
    {

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Hackney Id
        /// </summary>
        public int HackneyId { get; set; }

        /// <summary>
        /// Gets or sets the First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Middle Name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Date Of Birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Gets or sets the preferred contact.
        /// </summary>
        public string PreferredContact { get; set; }  // eg phone        
        /// <summary>
        /// Gets or sets the english speaking fluency of user.
        /// </summary>
        public string CanSpeakEnglish { get; set; }  // eg fluent

        /// <summary>
        /// Gets or sets the Address Line1
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the Address Line1
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the Address Line1
        /// </summary>
        public string AddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets the Town
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// Gets or sets the County
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the Post Code
        /// </summary>
        public string PostCode { get; set; }

        public int? PrimarySupportReasonId { get; set; }

        [ForeignKey(nameof(PrimarySupportReasonId))]
        public PrimarySupportReason PrimarySupportReason { get; set; }

    }

}
