using Microsoft.EntityFrameworkCore;
using ProjectManager.DataAccess;
using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Business
{
    public class UserBL : IUserBL
    {
        private readonly IProjectManagerContext _context;

        public UserBL(IProjectManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users                
                .OrderByDescending(m => m.Id)
                .ToList();
        }

        public IEnumerable<User> SearchUsers(string searchText)
        {
            return _context.Users
                .Where(m => searchText == null || (m.FirstName.Contains(searchText) ||
                            m.LastName.Contains(searchText) || m.EmployeeId.Contains(searchText)))
                .OrderByDescending(m => m.Id)
                .ToList();
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.SingleOrDefault(m => m.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
