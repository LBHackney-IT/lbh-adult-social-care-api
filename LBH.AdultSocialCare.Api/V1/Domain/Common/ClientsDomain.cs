using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class ClientsDomain
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
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

        public string PreferredContact { get; set; }  // eg phone
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

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public Guid CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updater Id
        /// </summary>
        public Guid? UpdaterId { get; set; }

        /// <summary>
        /// Gets or sets the Date Created
        /// </summary>
        public DateTimeOffset? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the Date Updated
        /// </summary>
        public DateTimeOffset? DateUpdated { get; set; }
    }
}
