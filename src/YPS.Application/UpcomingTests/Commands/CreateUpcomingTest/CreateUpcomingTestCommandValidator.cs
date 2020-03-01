using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.UpcomingTests.Commands.CreateUpcomingTest
{
    public class CreateUpcomingTestCommandValidator : AbstractValidator<CreateUpcomingTestCommand>
    {
        public CreateUpcomingTestCommandValidator()
        {
            RuleFor(v => v.ScheduledDate >= DateTime.Now.AddDays(1))
                .NotEmpty();

            RuleFor(v => v.Topic)
                .MaximumLength(254)
                .NotEmpty();

            RuleFor(v => v.TestType)
                .MaximumLength(254)
                .NotEmpty();
        }
    }
}
