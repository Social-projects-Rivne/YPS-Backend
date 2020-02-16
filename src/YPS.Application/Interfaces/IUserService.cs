using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPS.Application.Models;
using YPS.Domain.Entities;

namespace YPS.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(UserPartial user, string password, long roleId, long schoolId);
        Task<IDictionary<string, string>> CheckFailuresAsync(string email, string phoneNumber);
    }
}