using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Profiles;

namespace LBH.AdultSocialCare.Api.Tests
{
    public class BaseTest
    {
        public BaseTest()
        {
            var config = new MapperConfiguration(options =>
            {
                options.AddProfile<MappingProfile>();
                options.AddProfile<GeneratedMappingProfile>();
            });

            Mapper = config.CreateMapper();

            DomainToEntityFactory.Configure(Mapper);
            EntityToDomainFactory.Configure(Mapper);
            ResponseFactory.Configure(Mapper);
            ApiToDomainFactory.Configure(Mapper);
            MappingExtensions.Configure(Mapper);
        }

        protected IMapper Mapper { get; }
    }
}
