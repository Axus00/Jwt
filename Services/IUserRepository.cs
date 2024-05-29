using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers(); // traemos todos los usuarios
        User UserById(int id); // usuarios por id
        void Add(User user); // crear
        void Remove(int id); // eliminar
        void Update(int id); // actualizar
    }
}