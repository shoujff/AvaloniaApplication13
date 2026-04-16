using AvaloniaApplication13.Data;
using AvaloniaApplication13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication13.Repositories
{
   public class UserRepository : BaseRepository<User>
    {
        private readonly DataBase DataBase;
        
        public UserRepository() 
        { 
            DataBase = new DataBase();
            
        }
        public User CreateUser(User user)
        {
            DataBase.Users.Add(user);
            DataBase.SaveChanges();
            return user;

        }
        public List<User> GetAllUsers()
        {
            return DataBase.Users.ToList();
        }
        public User GetById(int id)
        {
            return DataBase.Users.FirstOrDefault(i => i.Id == id);
        }
        public User GetByLogin(string login)
        {
            return DataBase.Users.FirstOrDefault(i => i.Login == login);
        }
        public bool UserExists(string login)

        {
            return DataBase.Users.Any(u => u.Login == login);
        }

    }
}
