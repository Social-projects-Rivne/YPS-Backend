using AutoMapper;
using YPS.Application.Mapping;

namespace YPS.Application.UnitTests.Mapping
{
    public sealed class MappingTestsFixture
    {
        public IConfigurationProvider ConfigurationProvider { get; }
        public IMapper Mapper { get; }

        public MappingTestsFixture()
        {
            ConfigurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = ConfigurationProvider.CreateMapper();
        }
    }
}
