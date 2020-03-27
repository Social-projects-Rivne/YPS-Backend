using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.JournalColumns.Commands.CreateJournalColumn
{
    public class CreateJournalColumnCommandValidator : AbstractValidator<CreateJournalColumnCommand>
    {
        public CreateJournalColumnCommandValidator()
        {
            RuleFor(v => v.ClassId )
                .NotEmpty();

            RuleFor(v => v.Topic)
                .MaximumLength(254)
                .NotEmpty();

            RuleFor(v => v.LessonId)
                .NotEmpty();
        }
    }
}
