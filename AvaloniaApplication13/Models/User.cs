using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication13.Models
{
    public class User
    {
        private static int _nextId = 1;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int  Id { get; set; }
        public bool IsLogin { get; set; } = false;
       public User(string name, string surname, string login, string password)
        {
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
            Id = _nextId++;
            
        }
    }
   
}
