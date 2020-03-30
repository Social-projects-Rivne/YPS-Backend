using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Disciplines.Queries.GetDisciplinesByTeacher;
using YPS.Persistence;
using YPS.Application.UnitTests.Mapping;
using Xunit;
using Shouldly;
using YPS.Domain.Entities;
using System.Linq;
using static YPS.Application.Disciplines.Queries.GetDisciplinesByTeacher.GetDisciplinesByTeacherQuery;

namespace YPS.Application.UnitTests.Disciplines.Queries.GetDisciplinesByTeacher
{
    [Collection("QueryTests")]
    public class GetDisciplinesByTeacherTests
    {
        public readonly YPSDbContext _context;
        public readonly IMapper _mapper;

        public GetDisciplinesByTeacherTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCocrectVmAndListCount() 
        {
            var query = new GetDisciplinesByTeacherQuery { TeacherId = 5 };

            var handle = new GetDisciplinesByTeacherQueryHandler(_context, _mapper);

            var result = await handle.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<List<DisciplineVm>>();

            result.Count.ShouldBe(1);
        } 
    }
}
