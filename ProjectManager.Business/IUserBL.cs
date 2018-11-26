using System.Collections.Generic;
using ProjectManager.Entities;

namespace ProjectManager.Business
{
    public interface IUserBL
    {
        int AddUser(User user);
        void DeleteUser(int id);
        IEnumerable<User> GetUsers();
        IEnumerable<User> SearchUsers(string searchText);
        User UpdateUser(User user);
    }
}