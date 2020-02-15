using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public sealed class UserRefreshToken : EntityBase
    {
        [MaxLength(50)]
        public string RefreshToken { get; set; }

        public DateTime ExpiryDate { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }
    }
}
