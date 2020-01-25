using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using MediatR;

namespace YPS.Application.Auth.Command.CreateHeadMaster
{
    public sealed class CreateHeadMasterCommand: IRequest<User>
    {
        //public string FirstName { get; set; }
        //public string Surname { get; set; }
        //public string MiddleName { get; set; }
        //public string PhoneNumber { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        //public DateTime DateOfBirth { get; set; }
    }

    
}
