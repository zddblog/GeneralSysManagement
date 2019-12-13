using System;
using System.Collections.Generic;

namespace General.Entities.GeneralModels
{
    public partial class SysUserToken
    {
        public int Id { get; set; }
        public string SysUerId { get; set; }
        public DateTime? ExpireTime { get; set; }
    }
}
