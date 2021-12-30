using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class UserCredentialEntity
    {
        public int Id { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Flag { get; set; }
        public int EmailFlag { get; set; }
        public DateTime EmailSentOn { get; set; }
        public string IP_ADDRESS { get; set; }
        public DateTime LAST_lOGIN { get; set; }
        public DateTime CurrentLogin_time { get; set; }
        public string JsonResponse { get; set; }

        public virtual UserDetailsMasterEntity UserDetailsMaster { get; set; }
        public virtual RoleMasterEntity RoleMaster { get; set; }
    }
}
