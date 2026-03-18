using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpsATM.Application.DTOs
{
    public class RegisterUserDto
    {

        public string FullName { get; set; }
        public string Email { get; set; }
        public string EmpId { get; set; }
        public string Phone {  get; set; }
        public string Password { get; set; }
    }
}
