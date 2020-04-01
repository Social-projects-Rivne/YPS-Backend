using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YPS.Application.Schools.Queries.GetSchoolById;
using YPS.Persistence;

namespace YPS.Application.UnitTests.Schools.GetSchoolById
{
    [Collection("QueryTests")]
    public sealed class GetSchoolByIdQueryTests
    {
        private readonly YPSDbContext _context;
        private readonly IMapper _mapper;

        public GetSchoolByIdQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task Handle_ReturnsCorrectVm(long schoolId)
        {
            GetSchoolByIdQuery query = new GetSchoolByIdQuery { SchoolId = schoolId };
            GetSchoolByIdQuery.GetSchoolByIdQueryHandler handler = new GetSchoolByIdQuery.GetSchoolByIdQueryHandler(_context, _mapper);

            SchoolVm result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<SchoolVm>();
            result.ShouldNotBeNull();
        }
    }
}
