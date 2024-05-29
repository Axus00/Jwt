using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Services;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserDeleteController : ControllerBase
    {
       
        private readonly BaseContext _context;
        private readonly IUserRepository _userRepository;
        public UserDeleteController(IUserRepository userRepository , BaseContext context)
        {
            _context = context;
            _userRepository = userRepository;
        }

        //endpoints
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            _userRepository.Remove(id);
            return Ok("The user has been deleted");
        }

    }
}