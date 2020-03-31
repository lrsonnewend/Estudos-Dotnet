using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Livraria.Models;
using Livraria.Services;
using Livraria.Repository;

namespace Livraria.Controllers
{
    [Route("/account")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
            {
                return NotFound(new { message = "usuario ou senha incorreto." });
            }

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            return new { user = user, token = token };
        }
    }
}