using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Core.DTO
{
    public class SignUpDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public string SessionId { get; set; }
        public string Nickname { get; set; }
        public string FullName { get; set; }
    }
}
