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

    }
}
