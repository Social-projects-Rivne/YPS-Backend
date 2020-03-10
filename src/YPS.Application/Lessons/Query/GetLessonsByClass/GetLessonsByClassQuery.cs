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

namespace YPS.Application.Lessons.Query.GetLessonsByClass
{
    public class GetLessonsByClassQuery : IRequest<ICollection<GetLessonsByClassVm>>
    {
        public long ClassId { get; set; }

        public class GetLessonsByClassQueryHandler : IRequestHandler<GetLessonsByClassQuery, ICollection<GetLessonsByClassVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;
            public GetLessonsByClassQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ICollection<GetLessonsByClassVm>> Handle(GetLessonsByClassQuery request, CancellationToken cancellationToken)
            {
                var lessons = _context.Lessons
                    .Where(x => x.ClassId == request.ClassId && x.LessonDate.Month == DateTime.Now.Month)
                    .OrderBy(x => x.LessonDate);
                ICollection<GetLessonsByClassVm> vm = new List<GetLessonsByClassVm>();
                foreach (var lesson in lessons)
                {
                    vm.Add(new GetLessonsByClassVm
                    {
                        Date = lesson.LessonDate.ToString("MMMM dd"),
                        DayName = lesson.LessonDate.DayOfWeek.ToString(),
                        Items = await lessons.Where(x=>x.LessonDate.Day==lesson.LessonDate.Day).ProjectTo<LessonByClassDto>(_mapper.ConfigurationProvider).ToListAsync()
                    });
                }
                return vm;
            }
        }
    }
}
