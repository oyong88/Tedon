using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tedon.Web.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Tedon.Web.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string id, string pwd)
        {
            if(string.IsNullOrEmpty(id))
            {
                return Json(new
                {
                    code = -1,
                    message = "아이디를 입력해주세요."
                });
            }

            if (string.IsNullOrEmpty(pwd))
            {
                return Json(new
                {
                    code = -1,
                    message = "패스워드를 입력해주세요."
                });
            }

            if(LoginUser(id, pwd))
            {
                //로그인 성공
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, id)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.Authentication.SignInAsync("Tedon.Auth", principal);

                return Json(new
                {
                    code = 0,
                    message = "OK"
                });
            }
            else
            {
                return Json(new
                {
                    code = -9,
                    message = "로그인에 실패하였습니다."
                });
            }

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Tedon.Auth");
            return Redirect("/");
        }

        private bool LoginUser(string id, string pwd)
        {
            var login = Config.GetSection("Login");

            if(id == login["Id"] && pwd == login["Pwd"])
            {
                return true;
            }

            return false;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }

    }
}
