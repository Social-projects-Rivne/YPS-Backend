using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace YPS.Application.Classes.Commands.CreateClass
{
    public class CreateClassRequestCommand : IRequest<long>
    {
        public long Number { get; set; }
        public string Character { get; set; }
        public long ClassTeacherId { get; set; }
    }
}
