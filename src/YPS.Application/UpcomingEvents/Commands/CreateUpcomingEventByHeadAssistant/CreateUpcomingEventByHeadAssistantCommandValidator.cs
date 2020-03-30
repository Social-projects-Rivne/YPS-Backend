using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.Application.UpcomingEvents.Commands.CreateUpcomingEventByHeadAssistant
{
    public class CreateUpcomingEventByHeadAssistantCommandValidator : AbstractValidator<CreateUpcomingEventByHeadAssistantCommand>
    {
        private readonly IYPSDbContext _context;
        public CreateUpcomingEventByHeadAssistantCommandValidator(IYPSDbContext context)
        {
            _context = context;

            RuleFor(v => v.ScheduledDate >= DateTime.Now.AddDays(1))
                .NotEmpty().WithMessage("Schedule date is required.");

            RuleFor(v => v.Title)
                .MaximumLength(254).WithMessage("Title must not exceed 254 characters.")
                .NotEmpty().WithMessage("Title is required");

            RuleFor(v => v.Content)
                .MaximumLength(254).WithMessage("Content must not exceed 254 characters.")
                .NotEmpty().WithMessage("Content is required");
        }

        public async Task<bool> Exist(DateTime scheduledate, string title, string content, CancellationToken cancellationToken)
        {
            return await _context.UpcomingEvents
                .AllAsync(s => s.ScheduledDate == scheduledate && s.Title == title && s.Content == content);
        }
    }
}
