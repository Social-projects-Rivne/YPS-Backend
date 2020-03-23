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

namespace YPS.Application.Lessons.Queries.GetLessonsByTeacher
{
    public sealed class GetLessonsByTeacherQuery : IRequest<List<LessonByTeacherVm>>
    {
        public long TeacherId { get; set; }

        public class GetLessonsByTeacherQueryHandler : IRequestHandler<GetLessonsByTeacherQuery, List<LessonByTeacherVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetLessonsByTeacherQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<LessonByTeacherVm>> Handle(GetLessonsByTeacherQuery request, CancellationToken cancellationToken)
            {
                DateTime dt = DateTime.Now;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;

                DateTime firstDay = new DateTime(dt.Year, dt.Month, 1);
                DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);

                List<LessonByTeacherVm> vm = new List<LessonByTeacherVm>();

                List<LessonByTeacherDto> lessons = await _context.Lessons
                    .Where(t => t.TeacherId == request.TeacherId && t.LessonDate.Month == DateTime.Now.Month).OrderBy(e => e.LessonDate)
                    .ThenBy(e => e.LessonNumber)
                    .ProjectTo<LessonByTeacherDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                for (int i = 0; i < lastDay.Day; i++)
                {
                    vm.Add(
                        new LessonByTeacherVm
                        {
                            DayName = firstDay.DayOfWeek.ToString(),
                            Date = firstDay.ToString("MMMM dd", CultureInfo.InvariantCulture),
                            Lessons = new List<LessonByTeacherDto>()
                        }
                    );

                    vm.ElementAt(i).Lessons.AddRange(lessons.Where(x => x.LessonDate == firstDay.ToString("dd.MM.yyyy")));

                    firstDay = firstDay.AddDays(1);
                }
                vm = vm.Where(x => x.Lessons.Count != 0).ToList();

                return vm;
            }
        }
    }
}
