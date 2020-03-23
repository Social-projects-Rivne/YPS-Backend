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

                Class classOfPupil = await _context.ClassesToPupils
                    .Where(x => x.PupilId == request.Id)
                    .Select(x => x.Class)
                    .FirstOrDefaultAsync(x => x.YearFrom == DateTime.Now.Year || x.YearTo == DateTime.Now.Year);

                List<ScheduleItemDto> lessons = await _context.Lessons
                    .Where(x => x.Class.Id == classOfPupil.Id && x.LessonDate >= firstDay && x.LessonDate <= firstDay.AddDays(7))
                    .ProjectTo<ScheduleItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return _scheduleService.MapSchedule(firstDay, lessons);
            }
        }
    }
}
