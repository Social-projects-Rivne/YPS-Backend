using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YPS.Application.Classes.Queries.GetClassesBySchool;
using YPS.Persistence;

namespace YPS.Application.UnitTests.Classes.Queries.GetClassesBySchool
{
    [Collection("QueryTests")]
    public class GetClassesBySchoolQueryTest
    {
        public readonly YPSDbContext _context;
        public readonly IMapper _mapper;

        public GetClassesBySchoolQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task Handle_ReturnsCorrectVm(long schoolId)
        {
            GetClassesBySchoolQuery query = new GetClassesBySchoolQuery { SchoolId = schoolId };
            GetClassesBySchoolQuery.GetClassesBySchoolQueryHandler handler = new GetClassesBySchoolQuery.GetClassesBySchoolQueryHandler(_context, _mapper);

            ICollection<ClassBySchoolVm> result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<ICollection<ClassBySchoolVm>>();
            result.ShouldNotBeNull();
        }
    }
}
