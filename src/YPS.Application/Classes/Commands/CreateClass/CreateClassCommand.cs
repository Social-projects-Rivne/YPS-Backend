using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YPS.Application.Interfaces;
using YPS.Application.Models;
using YPS.Domain.Entities;

namespace YPS.Application.Classes.Commands.CreateClass
{
    public class CreateClassCommand : IRequest<long>
    {
        public string Character { get; set; }
        public long Number { get; set; }
        public long ClassTeacherId { get; set; }
        public List<long> SelectedPupils { get; set; }

        public sealed class CreateClassCommandHandler : IRequestHandler<CreateClassCommand,long>
        {
            private readonly IYPSDbContext _context;
            public CreateClassCommandHandler(IYPSDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateClassCommand request, CancellationToken cancellationToken)
            {

                Class newClass = new Class
                {
                    Number = request.Number,
                    Character = request.Character.ToUpper(),
                    ClassTeacherId = request.ClassTeacherId,
                };

                _context.Classes.Add(newClass);
                await _context.SaveChangesAsync();
                Class createdClass = await _context.Classes.FindAsync(newClass.Id);
                if (createdClass != null)
                {
                    foreach (var pupil in request.SelectedPupils)
                    {
                        ClassToPupil classToPupil = new ClassToPupil
                        {
                            ClassId = createdClass.Id,
                            PupilId = pupil
                        };
                        _context.ClassesToPupils.Add(classToPupil);
                    }
                    await _context.SaveChangesAsync();
                }
                Journal newJournal = new Journal
                {
                    ClassId = newClass.Id
                };
                _context.Journals.Add(newJournal);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return newClass.Id;

            }
        }
    }
}
