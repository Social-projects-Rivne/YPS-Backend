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
using YPS.Domain.Entities;

namespace YPS.Application.Disciplines.Queries.GetDisciplinesByTeacher
{
    public class GetDisciplinesByTeacherQuery : IRequest<List<DisciplineVm>>
    {
        public long TeacherId { get; set; }

        public class GetDisciplinesByTeacherQueryHandler : IRequestHandler<GetDisciplinesByTeacherQuery, List<DisciplineVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetDisciplinesByTeacherQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<DisciplineVm>> Handle(GetDisciplinesByTeacherQuery request, CancellationToken cancellationToken)
            {
                Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == request.TeacherId);

                List<DisciplineVm> disciplinesList = await _context.TeacherToDisciplines
                    .Where(x => x.TeacherId == request.TeacherId)
                    .ProjectTo<DisciplineVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return disciplinesList;
            }
        }
    }
}
