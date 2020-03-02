using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Application.Models;
using YPS.Domain.Entities;

namespace YPS.Application.UpcomingTests.Commands.CreateUpcomingTest
{
    public class CreateUpcomingTestCommand : IRequest<long>
    {
        public long TeacherId { get; set; }
        public string Topic { get; set; }
        public string TestType { get; set; }
        public long ClassId { get; set; }
        public long DisciplineId { get; set; }
        public DateTime ScheduledDate { get; set; }

        public sealed class CreateUpcomingTestCommandHandler : IRequestHandler<CreateUpcomingTestCommand, long>
        {
            private readonly IYPSDbContext _context;

            public CreateUpcomingTestCommandHandler(IYPSDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateUpcomingTestCommand request, CancellationToken cancellationToken)
            {
                UpcomingTest test = new UpcomingTest() 
                {
                    Date = DateTime.Now,
                    ScheduledDate = request.ScheduledDate,
                    Topic = request.Topic,
                    TestType = request.TestType,
                    ClassId = request.ClassId,
                    DisciplineId = request.DisciplineId,
                    TeacherId = request.TeacherId
                };

                _context.UpcomingTests.Add(test);
                await _context.SaveChangesAsync(cancellationToken);

                return test.Id;
            }
        }
    }
}
