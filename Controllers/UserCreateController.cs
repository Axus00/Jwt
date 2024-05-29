using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserCreateController : ControllerBase
    {
        private readonly BaseContext _context;
        private readonly IUserRepository _userRepository;
        public UserCreateController(IUserRepository userRepository , BaseContext context)
        {
            _context = context;
            _userRepository = userRepository;
        }

        //endpoints
        [HttpPost("create")]
        public IActionResult Create([FromBody] User user)
        {
            _userRepository.Add(user);
            return Ok("The user has been created");
        }
    }
}