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

namespace YPS.Application.Schedule.Query.GetScheduleByClass
{
    public class GetScheduleByClassQuery : IRequest<ICollection<GetScheduleByClassVm>>
    {
        public long ClassId { get; set; }

        public class GetScheduleByClassQueryHandler : IRequestHandler<GetScheduleByClassQuery, ICollection<GetScheduleByClassVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;
            public GetScheduleByClassQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ICollection<GetScheduleByClassVm>> Handle(GetScheduleByClassQuery request, CancellationToken cancellationToken)
            {
                var lessons = _context.Lessons
                    .Where(x => x.ClassId == request.ClassId && x.LessonDate.Month == DateTime.Now.Month)
                    .OrderBy(x=>x.LessonDate);
                ICollection<GetScheduleByClassVm> vm = new List<GetScheduleByClassVm>();
                foreach (var lesson in lessons)
                {
                    if (vm.FirstOrDefault(x => x.Date == lesson.LessonDate.ToString("MMMM dd")) == null)
                    {
                        vm.Add(new GetScheduleByClassVm
                        {
                            Date = lesson.LessonDate.ToString("MMMM dd"),
                            DayName = lesson.LessonDate.DayOfWeek.ToString(),
                            Items = await lessons
                        .Where(x => x.LessonDate.Day == lesson.LessonDate.Day)
                        .ProjectTo<ScheduleByClassDto>(_mapper.ConfigurationProvider)
                        .ToListAsync()
                        });
                    }
                    else
                    {
                        continue;
                    }                    
                }
                return vm;
            }
        }
    }
}
