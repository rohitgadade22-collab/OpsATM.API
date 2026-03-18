using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpsATM.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }
        public string EmpId { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
    }
}
