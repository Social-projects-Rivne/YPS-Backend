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
using YPS.Application.Schedule.Models;
using YPS.Domain.Entities;

namespace YPS.Application.Schedule.Query.GetScheduleByClass
{
    public class GetScheduleByClassQuery : IRequest<ICollection<ScheduleVm>>
    {
        public long ClassId { get; set; }

        public class GetScheduleByClassQueryHandler : IRequestHandler<GetScheduleByClassQuery, ICollection<ScheduleVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;
            private readonly IScheduleService _scheduleService;
            private readonly IDateTimeSevice _dateTimeSevice;

            public GetScheduleByClassQueryHandler(IYPSDbContext context, IMapper mapper, IScheduleService scheduleService, IDateTimeSevice dateTimeSevice)
            {
                _context = context;
                _mapper = mapper;
                _scheduleService = scheduleService;
                _dateTimeSevice = dateTimeSevice;
            }

            public async Task<ICollection<ScheduleVm>> Handle(GetScheduleByClassQuery request, CancellationToken cancellationToken)
            {
                DateTime firstDay = _dateTimeSevice.GetFirstDayOfWeek();

                List<ScheduleItemDto> lessons = await _context.Lessons
                    .Where(x => x.Class.Id == request.ClassId && x.LessonDate >= firstDay && x.LessonDate <= firstDay.AddDays(7))
                    .ProjectTo<ScheduleItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return _scheduleService.MapSchedule(firstDay, lessons);
            }
        }
    }
}
