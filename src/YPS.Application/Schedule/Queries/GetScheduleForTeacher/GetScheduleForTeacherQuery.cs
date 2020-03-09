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

namespace YPS.Application.Schedule.Queries.GetScheduleForTeacher
{
    public sealed class GetScheduleForTeacherQuery : IRequest<List<ScheduleVm>>
    {
        public long Id { get; set; }

        public sealed class GetScheduleForTeacherQueryHandler : IRequestHandler<GetScheduleForTeacherQuery, List<ScheduleVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetScheduleForTeacherQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ScheduleVm>> Handle(GetScheduleForTeacherQuery request, CancellationToken cancellationToken)
            {
                DateTime dt = DateTime.Now;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                int difference = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;

                if (difference < 0)
                    difference += 7;

                DateTime firstDay = dt.AddDays(-difference).Date;

                List<ScheduleVm> vm = new List<ScheduleVm>();

                var lessons = await _context.Lessons
                    .Where(x => x.TeacherId == request.Id)
                    .ProjectTo<ScheduleItemDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                for (int i = 0; i < 7; i++)
                {
                    vm.Add(
                        new ScheduleVm
                        {
                            DayName = firstDay.DayOfWeek.ToString(),
                            Date = firstDay.ToString("MMMM dd", CultureInfo.InvariantCulture),
                            Items = new List<ScheduleItemDto>()
                        }
                    );

                    vm.ElementAt(i).Items.AddRange(lessons.Where(x => x.LessonDate == firstDay.ToString("dd.MM.yyyy")));

                    firstDay = firstDay.AddDays(1);
                }

                return vm;
            }
        }
    }
}
