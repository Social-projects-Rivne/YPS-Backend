using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using YPS.Application.Interfaces;
using YPS.Domain.Entities;

namespace YPS.Application.Lessons.Commands.CreateLesson
{
    public sealed class CreateLessonCommand : IRequest<long>
    {
        public ushort LessonNumber { get; set; }
        public string LessonDate { get; set; }
        public string LessonTimeGap { get; set; }
        public long AuditoriumId { get; set; }
        public long DisciplineId { get; set; }
        public long TeacherId { get; set; }
        public long ClassId { get; set; }
        public long? WeekCopyCount { get; set; }

        public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, long>
        {
            private readonly IYPSDbContext _context;

            public CreateLessonCommandHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
            {
                DateTime localDate = DateTime.Parse(request.LessonDate);

                Lesson newLesson = new Lesson
                {
                    ClassId = request.ClassId,
                    DisciplineId = request.DisciplineId,
                    TeacherId = request.TeacherId,
                    LessonDate = localDate,
                    LessonNumber = request.LessonNumber,
                    LessonTimeGap = request.LessonTimeGap,
                    AuditoriumId = request.AuditoriumId
                };

                _context.Lessons.Add(newLesson);

                if (request.WeekCopyCount != null && request.WeekCopyCount != 0)
                {
                    for (int i = 1; i <= request.WeekCopyCount; i++)
                    {
                        _context.Lessons.Add(
                            new Lesson
                            {
                                ClassId = request.ClassId,
                                DisciplineId = request.DisciplineId,
                                TeacherId = request.TeacherId,
                                LessonDate = localDate.AddDays(7 * i),
                                LessonNumber = request.LessonNumber,
                                LessonTimeGap = request.LessonTimeGap,
                                AuditoriumId = request.AuditoriumId
                            }
                        );
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);

                return newLesson.Id;
            }
        }
    }
}
