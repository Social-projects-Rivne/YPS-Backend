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

namespace YPS.Application.Lessons.Queries.GetLessonsByTeacher
{
    public sealed class GetLessonsByTeacherQuery : IRequest<List<LessonByTeacherVm>>
    {
        public long TeacherId { get; set; }

        public class Handler : IRequestHandler<GetLessonsByTeacherQuery, List<LessonByTeacherVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<LessonByTeacherVm>> Handle(GetLessonsByTeacherQuery request, CancellationToken cancellationToken)
            {
                List<LessonByTeacherVm> result = await _context.Lessons
                    .Where(t => t.TeacherToDiscipline.TeacherId == request.TeacherId).OrderBy(e => e.LessonDate)
                    .ProjectTo<LessonByTeacherVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return result;
            }
        }
    }
}
