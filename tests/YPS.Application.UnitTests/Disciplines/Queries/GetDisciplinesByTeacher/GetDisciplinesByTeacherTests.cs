using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Disciplines.Queries.GetDisciplinesByTeacher;
using YPS.Persistence;
using static YPS.Application.Disciplines.Queries.GetDisciplinesByTeacher.GetDisciplinesByTeacherQuery;
using Xunit;
using Shouldly;
using YPS.Domain.Entities;
using System.Linq;

namespace YPS.Application.UnitTests.Disciplines.Queries.GetDisciplinesByTeacher
{
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
        public async Task Handle_ReturnsCocrectVmAndListCount() {

            long testTeacherId = 5;
            var user = _context.Teachers.SingleOrDefault(x => x.Id == testTeacherId);
            var query = new GetDisciplinesByTeacherQuery();
            var handle = new GetDisciplinesByTeacherQueryHandler(_context, _mapper);
            var result = await handle.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<DisciplineVm>();
        } 
    }
}
