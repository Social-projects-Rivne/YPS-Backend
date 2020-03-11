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

namespace YPS.Application.Schedule.Queries.GetScheduleForPupil
{
    public sealed class GetScheduleForPupilQuery : IRequest<List<ScheduleVm>>
    {
        public long Id { get; set; }

        public sealed class GetScheduleForPupilQueryHandler : IRequestHandler<GetScheduleForPupilQuery, List<ScheduleVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;
            private readonly IDateTimeSevice _dateTimeSevice;
            private readonly IScheduleService _scheduleService;

            public GetScheduleForPupilQueryHandler(IYPSDbContext context, IMapper mapper, IDateTimeSevice dateTimeSevice, IScheduleService scheduleService)
            {
                _context = context;
                _mapper = mapper;
                _dateTimeSevice = dateTimeSevice;
                _scheduleService = scheduleService;
            }

            public async Task<List<ScheduleVm>> Handle(GetScheduleForPupilQuery request, CancellationToken cancellationToken)
            {
                DateTime firstDay = _dateTimeSevice.GetFirstDayOfWeek();

                Pupil pupil = await _context.Pupils.SingleOrDefaultAsync(x => x.Id == request.Id);

                Class pupilsClass = await _context.Classes.FirstAsync(x => x.YearFrom.Year == DateTime.Now.Year || x.YearTo.Year == DateTime.Now.Year);

                List<ScheduleItemDto> lessons = await _context.Lessons
                    .Where(x => x.Class.Id == pupilsClass.Id && x.LessonDate >= firstDay && x.LessonDate <= firstDay.AddDays(7))
                    .ProjectTo<ScheduleItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return _scheduleService.MapSchedule(firstDay, lessons);
            }
        }
    }
}
