using System;
using System.Collections.Generic;

namespace General.Entities.GeneralModels
{
    public partial class SysUser
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool Enabled { get; set; }
        public bool IsAdmin { get; set; }
        public int LoginFailedNum { get; set; }
        public DateTime? AllowLoginTime { get; set; }
        public bool? LoginLock { get; set; }
        public bool IsDeleted { get; set; }
    }
}
