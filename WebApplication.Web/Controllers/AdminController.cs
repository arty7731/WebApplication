using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication.Core.DTO;
using WebApplication.Core.Enums;
using WebApplication.Core.Interfaces.Business;
using WebApplication.Web.Models.Admin;

namespace WebApplication.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserManager userManager;
        private readonly IMapper mapper;

        public AdminController(IUserManager userManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult ChangeRole(int Id, int roleId)
        {
            this.userManager.ChangeStatus(Id, roleId);
            return null;
        }

        // GET: Admin
        public ActionResult Index()
        {
            IEnumerable<UserDto> users = this.userManager.GetAll();

            List<dynamic> roleList = new List<dynamic>();

            foreach (RoleType r in Enum.GetValues(typeof(RoleType)))
            {
                roleList.Add(new { Name = Enum.GetName(typeof(RoleType), r), Value = Convert.ToInt32(r)});
            }

            ViewBag.Roles = new SelectList(roleList, "Value", "Name");

            IEnumerable<UserModelView> result = this.mapper.Map<IEnumerable<UserDto>, IEnumerable<UserModelView>>(users);
            return View(result);
        }
    }
}