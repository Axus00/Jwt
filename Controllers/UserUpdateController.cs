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
    public class UserUpdateController : ControllerBase
    {
        private readonly BaseContext _context;
        private readonly IUserRepository _userRepository;
        public UserUpdateController(IUserRepository userRepository , BaseContext context)
        {
            _context = context;
            _userRepository = userRepository;
        }

        //endpoints
        [HttpPut("update")]
        public IActionResult Update(int id)
        {
            _userRepository.Update(id);
            return Ok();
        }
    }
}