using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Application.Schedule.Models;

namespace YPS.Application.Schedule.Queries.GetScheduleForTeacher
{
    public sealed class GetScheduleForTeacherQuery : IRequest<List<ScheduleVm>>
    {
        public long Id { get; set; }

        public sealed class GetScheduleForTeacherQueryHandler : IRequestHandler<GetScheduleForTeacherQuery, List<ScheduleVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;
            private readonly IDateTimeService _dateTimeSevice;
            private readonly IScheduleService _scheduleService;

            public GetScheduleForTeacherQueryHandler(IYPSDbContext context, IMapper mapper, IDateTimeService dateTimeSevice, IScheduleService scheduleService)
            {
                _context = context;
                _mapper = mapper;
                _dateTimeSevice = dateTimeSevice;
                _scheduleService = scheduleService;
            }

            public async Task<List<ScheduleVm>> Handle(GetScheduleForTeacherQuery request, CancellationToken cancellationToken)
            {
                DateTime firstDay = _dateTimeSevice.GetFirstDayOfWeek();

                List<ScheduleItemDto> lessons = await _context.Lessons
                    .Where(x => x.TeacherId == request.Id && x.LessonDate >= firstDay && x.LessonDate <= firstDay.AddDays(7))
                    .ProjectTo<ScheduleItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return _scheduleService.MapSchedule(firstDay, lessons);
            }
        }
    }
}
