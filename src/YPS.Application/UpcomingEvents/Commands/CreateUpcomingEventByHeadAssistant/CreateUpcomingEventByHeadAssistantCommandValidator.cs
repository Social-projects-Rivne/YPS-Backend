using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.UpcomingEvents.Commands.CreateUpcomingEventByHeadAssistant
{
    class CreateUpcomingEventByHeadAssistantCommandValidator : AbstractValidator<CreateUpcomingEventByHeadAssistantCommand>
    {
        public CreateUpcomingEventByHeadAssistantCommandValidator()
        {
            RuleFor(v => v.ScheduledDate >= DateTime.Now.AddDays(1))
                .NotEmpty();

            RuleFor(v => v.Title)
                .MaximumLength(254)
                .NotEmpty();

            RuleFor(v => v.Content)
                .MaximumLength(254)
                .NotEmpty();
        }
    }
}
