using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Request
{
    public class StatusRequest
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Status Name
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }
    }
}
