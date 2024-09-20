using System;
using System.Collections.Generic;
using System.Text;

namespace VOL.Entity.DomainModels.System.partial
{
    public class Sys_RegisterModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role_Id { get; set; }
        public string VerificationCode { get; set; }
        public string UUID { get; set; }
    }
}
