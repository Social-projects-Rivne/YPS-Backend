using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using FluentValidation;
using MediatR;

namespace YPS.Application.Auth.Command.Login
{
    public sealed class LoginCommand : IRequest<LoginViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [IgnoreDataMember]
        public string ApiKey { get; set; }
    }
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            base.RuleFor(customer => customer.Email).NotNull().EmailAddress();  // If you want write your message add .WithMessage("")
        }
    }
}
