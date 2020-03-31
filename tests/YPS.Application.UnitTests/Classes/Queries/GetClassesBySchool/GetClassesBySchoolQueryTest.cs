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

        [Fact]
        public async Task Handle_ReturnsCorrectVmAndListCount()
        {
            GetClassesBySchoolQuery query = new GetClassesBySchoolQuery { SchoolId = 2 };
            GetClassesBySchoolQuery.GetClassesBySchoolQueryHandler handler = new GetClassesBySchoolQuery.GetClassesBySchoolQueryHandler(_context, _mapper);

            List<ClassBySchoolVm> result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<List<ClassBySchoolVm>>();
            result.Count.ShouldBe(3);
        }
    }
}
