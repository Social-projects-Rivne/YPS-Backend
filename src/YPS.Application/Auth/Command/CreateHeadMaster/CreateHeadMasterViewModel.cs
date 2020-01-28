using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Auth.Command.CreateHeadMaster
{
    [JsonObject(Title = "CreateHeadMaster")]
    public sealed class CreateHeadMasterViewModel
    {
        public string FisrtName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long RoleId { get; set; }
        public string FirstName { get; internal set; }
    }
}
