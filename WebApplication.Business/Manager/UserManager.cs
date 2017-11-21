using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.DTO;
using WebApplication.Core.Enums;
using WebApplication.Core.Exceptions;
using WebApplication.Core.Interfaces.Business;
using WebApplication.Core.Interfaces.Repostories;
using WebApplication.Core.Interfaces.Shared;
using WebApplication.Core.Model;
using WebApplication.Data.Repositories;
using WebApplication.Data.Repositories.Shared;

namespace WebApplication.Business.Manager
{
    public class UserManager : ManagerBase, IUserManager
    {

        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserManager(IUnitOfWork unitOfWork,
            IMapper mapper,
            IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void ChangeStatus(int id, int roleId)
        {
            User user = this.userRepository.Find(id);
            user.RoleId = roleId;
            this.userRepository.Update(user);
            this.unitOfWork.Save();
        }

        public IEnumerable<UserDto> GetAll()
        {
            IEnumerable<User> users = this.userRepository.GetAll(new List<Expression<Func<User, object>>>
                {
                    u => u.Profile
                });

            IEnumerable<UserDto> result = users.Select(u =>
                new UserDto
                {
                    Email = u.Email,
                    FullName = u.Profile.FullName,
                    Id = u.Id,
                    Nickname = u.Profile.Nickname,
                    RoleID = u.RoleId.Value
                }).ToArray();

            return result;
        }

        public UserDto SignIn(string email, string password, string sessionId)
        {
            UserDto result = null;

            User user = userRepository.GetByEmail(email,
                new List<Expression<Func<User, object>>>
                {
                    u => u.Profile
                });

            if (user == null)
            {
                throw new UserException(UserErrorType.EmailNotExists);
            }

            if(user.Password != password)
            {
                throw new UserException(UserErrorType.IncorectPassword);
            }

            user.SessionId = sessionId;
            userRepository.Update(user);
            unitOfWork.Save();

            result = this.mapper.Map<User, UserDto>(user);

            return result;
        }

        public UserDto SignUp(SignUpDto signUp)
        {
            UserDto result = null;

            if (userRepository.GetByEmail(signUp.Email) != null)
            {
                throw new UserException(UserErrorType.EmailBusy);
            }

            Core.Model.Profile profile = new Core.Model.Profile
            {
                FullName = signUp.FullName,
                Nickname = signUp.Nickname,
                CountRating = 0,
                Rating = 0,
                Avatar = ""
            };

            User user = new User
            {
                Email = signUp.Email,
                Password = signUp.Password,
                RoleId = signUp.RoleId == 0 ? null : signUp.RoleId,
                SessionId = signUp.SessionId,
                Profile = profile,
            };

            this.userRepository.Insert(user);
            this.unitOfWork.Save();

            result = this.mapper.Map<User, UserDto>(user);

            return result;
        }
    }
}
