using AvaloniaApplication13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication13.Repositories
{
    public class BaseRepository<T> where T : User
    {
        public List<T> _items = new List<T>();
        public T Create(T item)
        {
            _items.Add(item);
            return item;
        }
        public T GetById(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }
        public List<T> GetAll()
        {
            return _items.ToList();
        }
        public bool Update(T item)
        {
            var item2 = GetById(item.Id);
            if (item2 != null)
            {
                item2.Name = item.Name;
                item2.Surname = item.Surname;
                item2.Password = item.Password;
                return true;
            }
            return true;

        }
        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
                _items.Remove(item);
        }
        public void Clear()
        {
            _items.Clear();
        }

        public int Count()
        {
            return _items.Count;
        }

    }

}
