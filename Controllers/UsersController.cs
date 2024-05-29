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
    public class UsersController : ControllerBase
    {
        private readonly BaseContext _context;
        private readonly IUserRepository _userRepository;
        
        public UsersController(IUserRepository userRepository , BaseContext context)
        {
            _context = context;
            _userRepository = userRepository;
        }

        //endpoints
        [HttpGet("all")]
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetUsers();
        }

        [HttpGet("all/{id}")]
        public User Details(int id)
        {
            return _userRepository.UserById(id);
        }
    }
}