using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.Application.Teachers.Queries.GetTeachersByDiscipline
{
    public class GetTeachersByDisciplineQuery : IRequest<ICollection<TeachersByDisciplineVm>>
    {
        public long DisciplineId { get; set; }
        public long SchoolId { get; set; }
        public class GetTeachersByDisciplineQueryHandler : IRequestHandler<GetTeachersByDisciplineQuery, ICollection<TeachersByDisciplineVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetTeachersByDisciplineQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ICollection<TeachersByDisciplineVm>> Handle(GetTeachersByDisciplineQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.TeacherToDisciplines
                    .Where(x => x.Teacher.User.SchoolId == request.SchoolId)
                    .Where(x => x.Discipline.Id == request.DisciplineId)
                    .Select(x => x.Teacher)
                    .ProjectTo<TeachersByDisciplineVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                return result;
            }
        }
    }
}
