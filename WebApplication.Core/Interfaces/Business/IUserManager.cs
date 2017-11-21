using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.DTO;
using WebApplication.Core.Model;

namespace WebApplication.Core.Interfaces.Business
{
    public interface IUserManager
    {
        UserDto SignIn(string email, string password, string sessionId);

        UserDto SignUp(SignUpDto signUp);
        IEnumerable<UserDto> GetAll();
        void ChangeStatus(int id, int roleId);
    }
}
