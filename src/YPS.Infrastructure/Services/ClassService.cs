using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Domain.Entities;

namespace YPS.Infrastructure.Services
{
    public class ClassService : IClassService
    {
        private readonly IYPSDbContext _context;

        public ClassService(IYPSDbContext context)
        {
            _context = context;
        }

        public async Task<Class> CreateClass(long number, string character, long teacherId)
        {
            Class newClass = new Class
            {
                Number = number,
                Character = character.ToUpper(),
                ClassTeacherId = teacherId
            };

            _context.Classes.Add(newClass);
            await _context.SaveChangesAsync();

            return await _context.Classes.SingleOrDefaultAsync(x => x.Id == newClass.Id);
        }

        private bool NumberValidation(long number) => number > 0 && number <= 12;

        private bool CharacterValidation(string character) => character.Length == 1;


        public IDictionary<string, string> CheckFailures(long number, string character)
        {
            IDictionary<string, string> failures = new Dictionary<string, string>();

            bool numberValid = NumberValidation(number);
            bool characterValid = CharacterValidation(character);

            if (numberValid == false)
                failures.Add("number", "number of the class is not valid");

            if (characterValid == false)
                failures.Add("character", "character is not valid");

            return failures;
        }
    }
}