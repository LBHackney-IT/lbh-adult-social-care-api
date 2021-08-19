using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response
{
    public class HomeCareStageResponse
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Stage Name
        /// </summary>
        public string StageName { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public Guid CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updater Id
        /// </summary>
        public Guid? UpdaterId { get; set; }
    }
}
