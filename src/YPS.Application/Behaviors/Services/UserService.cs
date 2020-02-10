using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Application.Models;
using YPS.Domain.Entities;

namespace YPS.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IYPSDbContext _context;

        public UserService(IYPSDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(UserPartial userPartial)
        {
            User user = new User
            {
                FirstName = userPartial.FirstName,
                Surname = userPartial.Surname,
                MiddleName = userPartial.MiddleName,
                PhoneNumber = userPartial.PhoneNumber,
                Email = userPartial.Email,
                Password = userPartial.Password,
                ImageUrl = "url",
                DateOfBirth = new DateTime(),
                RoleId = 2
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return await _context.Users.FindAsync(user.Id);
        }
    }
}