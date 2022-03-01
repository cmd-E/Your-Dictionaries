using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using YourDictionaries.EntityFramework.DataServices.Interfaces;

namespace YourDictionaries.ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly IUsersDataService _usersDataService;

        public UsersApiController(IUsersDataService usersDataService)
        {
            _usersDataService = usersDataService;
        }

        public JsonResult GetCurrentUser()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            //var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
            //var userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            //var response = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var toSend = new { Id = userId };
            return new JsonResult(toSend);
        }
    }
}
