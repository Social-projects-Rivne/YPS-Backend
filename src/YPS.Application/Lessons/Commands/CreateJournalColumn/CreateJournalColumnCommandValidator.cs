using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Lessons.Commands.CreateJournalColumn
{
    public class CreateJournalColumnCommandValidator : AbstractValidator<CreateJournalColumnCommand>
    {
        public CreateJournalColumnCommandValidator()
        {
            RuleFor(v => v.classId )
                .NotEmpty();

            RuleFor(v => v.topic)
                .MaximumLength(254)
                .NotEmpty();

            RuleFor(v => v.lessonId)
                .NotEmpty();
        }
    }
}
