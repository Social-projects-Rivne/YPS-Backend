using AutoMapper;
using System;
using Xunit;
using YPS.Application.Parents.Queries.GetParentsBySchool;
using YPS.Application.Pupils.Queries.GetPupilsBySchool;
using YPS.Domain.Entities;

namespace YPS.Application.UnitTests.Mapping
{
    public sealed class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
        
        [Theory]
        [InlineData(typeof(User), typeof(PupilBySchoolVm))]
        [InlineData(typeof(User), typeof(ParentBySchoolVm))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            object instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}
