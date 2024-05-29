using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly BaseContext _context;

        public UserRepository(BaseContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void Remove(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Update(int id)
        {
            var updateUser = _context.Users.Find(id);
            _context.Users.Update(updateUser);
            _context.SaveChanges(); 
        }

        public User UserById(int id)
        {
            return _context.Users.Find(id);
            throw new NotImplementedException();
        }
    }
}