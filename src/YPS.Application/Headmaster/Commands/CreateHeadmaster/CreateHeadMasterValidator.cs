using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Auth.Command.CreateHeadMaster
{
    class CreateHeadMasterValidator
    {
        public class CreateHeadMasterCommandValidator : AbstractValidator<CreateHeadMasterCommand>
        {
            public CreateHeadMasterCommandValidator()
            {
            }
        }
    }
}
