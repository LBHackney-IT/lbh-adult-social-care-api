using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{

    public class HomeCareServiceTypeMinutesSeed : IEntityTypeConfiguration<HomeCareServiceTypeMinutes>
    {

        public void Configure(EntityTypeBuilder<HomeCareServiceTypeMinutes> builder)
        {
            var dataToSeed = new List<HomeCareServiceTypeMinutes>();

            // ServiceTypeId : IsSecondary , [Minutes : MinutesLabel]
            IDictionary<(int, bool), IDictionary<int, string>> optionsToAdd =
                new Dictionary<(int, bool), IDictionary<int, string>>
                {
                    {
                        // Personal home care, primary
                        ((int) HomeCareServiceTypeEnum.Personal, false), _upTo2Hours
                    },
                    {
                        // Personal home care, secondary
                        ((int) HomeCareServiceTypeEnum.Personal, true), _naUpTo2Hours
                    },
                    {
                        // Domestic, primary
                        ((int) HomeCareServiceTypeEnum.Domestic, false), _upTo2Hours
                    },
                    {
                        // Live in, primary
                        ((int) HomeCareServiceTypeEnum.LiveIn, false), _upTo2Hours
                    },
                    {
                        // Escort, primary
                        ((int) HomeCareServiceTypeEnum.Escort, false), _upTo2Hours
                    }
                };

            int counter = 1;

            foreach (var ((serviceTypeId, isSecondaryCarer), serviceTypeMinuteEntries) in optionsToAdd)
            {
                dataToSeed.AddRange(serviceTypeMinuteEntries.Select(item => new HomeCareServiceTypeMinutes
                {
                    HomeCareServiceTypeId = serviceTypeId,
                    IsSecondaryCarer = isSecondaryCarer,
                    Id = counter++,
                    Label = item.Value,
                    Minutes = item.Key
                }));
            }

            builder.HasData(dataToSeed);
        }

        /// <summary>
        /// The minutes to minute labels, up to 2 hours, including N/A
        /// </summary>
        private static IDictionary<int, string> _naUpTo2Hours
        {
            get
            {
                IDictionary<int, string> noValueInitial = new Dictionary<int, string>
                {
                    {
                        0, "N/A"
                    }
                };

                foreach (var minutesToAdd in _upTo2Hours)
                {
                    noValueInitial.Add(minutesToAdd);
                }

                return noValueInitial;
            }
        }

        /// <summary>
        /// The minutes to minute labels, up to 2 hours
        /// </summary>
        private static readonly IDictionary<int, string> _upTo2Hours = new Dictionary<int, string>
        {
            {
                30, "30 minutes"
            },
            {
                45, "45 minutes"
            },
            {
                60, "1 hour"
            },
            {
                75, "1 hour 15 minutes"
            },
            {
                90, "1 hour 30 minutes"
            },
            {
                105, "1 hour 45 minutes"
            },
            {
                120, "2 hours"
            }
        };

    }

}
