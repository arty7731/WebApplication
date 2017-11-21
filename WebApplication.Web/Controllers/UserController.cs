using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Core.DTO;
using WebApplication.Core.Enums;
using WebApplication.Core.Exceptions;
using WebApplication.Core.Interfaces.Business;
using WebApplication.Web.Models.User.Response;

namespace WebApplication.Web.Controllers
{
    [RoutePrefix("")]
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        private readonly IMapper mapper;

        public UserController(IUserManager userManager,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("signIn")]
        public ActionResult SignIn()
        {
            UserMng.Clear();

            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string email, string password)
        {
            try
            {
                UserDto user = userManager.SignIn(email, password, HttpContext.Session.SessionID);

                UserMng.Current.Id = user.Id;
                UserMng.Current.IsSignIn = true;
                UserMng.Current.IsAdmin = user.RoleID == (int)RoleType.Admin;
                UserMng.Current.Email = user.Email;
                UserMng.Current.FullName = user.FullName;
                UserMng.Current.Nickname = user.Nickname;
                UserMng.Current.Role = (RoleType)user.RoleID;
            }
            catch (UserException ex)
            {
                ViewBag.error = ex.Message;
                ViewBag.Email = email;

                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("signup")]
        public ActionResult SignUp()
        {
            UserMng.Clear();

            return View(new SignUpResponse());
        }

        [HttpPost]
        public ActionResult SignUp(SignUpResponse res)
        {

            SignUpDto signUp = this.mapper.Map<SignUpResponse, SignUpDto>(res);
            signUp.RoleId = (int)RoleType.User;
            signUp.SessionId = HttpContext.Session.SessionID;
            try
            {
                UserDto user = this.userManager.SignUp(signUp);

                UserMng.Current.Id = user.Id;
                UserMng.Current.IsSignIn = true;
                UserMng.Current.Email = user.Email;
                UserMng.Current.FullName = user.FullName;
                UserMng.Current.Nickname = user.Nickname;
                UserMng.Current.Role = (RoleType)user.RoleID;
            }
            catch (UserException ex)
            {
                ViewBag.error = ex.Message;
                res.Password = "";
                return View(res);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            UserMng.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}