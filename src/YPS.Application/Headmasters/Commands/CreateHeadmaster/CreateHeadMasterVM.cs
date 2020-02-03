using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Application.Models;
using YPS.Domain.Entities;

namespace YPS.Application.Auth.Command.CreateHeadMaster
{
    [JsonObject(Title = "CreateHeadMaster")]
    public sealed class CreateHeadMasterVM : IMapFrom<User>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
