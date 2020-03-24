using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Application.Models;
using YPS.Domain.Entities;

namespace YPS.Application.UpcomingEvents.Commands.CreateUpcomingEventByHeadAssistant
{
    public class CreateUpcomingEventByHeadAssistantCommand : IRequest<long>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime ScheduledDate { get; set; }
        public long? ClassId { get; set; }
        public long TeacherId { get; set; }
        public long SchoolId { get; set; }

        public sealed class CreateUpcomingEventCommandHandler : IRequestHandler<CreateUpcomingEventByHeadAssistantCommand, long>
        {
            private readonly IYPSDbContext _context;

            public CreateUpcomingEventCommandHandler(IYPSDbContext context)
            {
                _context = context;
            }
            public async Task<long> Handle(CreateUpcomingEventByHeadAssistantCommand request, CancellationToken cancellationToken)
            {
                UpcomingEvent upcomingEvent = new UpcomingEvent()
                {
                    Title = request.Title,
                    Content = request.Content,
                    ScheduledDate = request.ScheduledDate,
                    TimeOfCreation = DateTime.Now,
                    ClassId = request.ClassId,
                    TeacherId = request.TeacherId,
                    SchoolId = request.SchoolId
                };
                _context.UpcomingEvents.Add(upcomingEvent);
                await _context.SaveChangesAsync(cancellationToken);
                return upcomingEvent.Id;       
            }
        }
    }
}
