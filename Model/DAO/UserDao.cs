using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.DAO
{
    public class UserDao
    {
        private WebFirst db;
        public UserDao()
        {
            db = new WebFirst();
        }
        
        public int Insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.IdUser;

        }

        public IEnumerable<User> GetAllUser(string search,int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.Username.Contains(search) || x.Fullname.Contains(search));
            }
            return model.OrderBy(x=>x.IdUser).ToPagedList(page, pageSize);
        }

        public bool Update(User user)
        {

            var us = db.Users.Find(user.IdUser);
            if (us != null)
            {
                us.Fullname = user.Fullname;
                us.Address = user.Address;
                us.Email = user.Email;
                us.Phone = user.Phone;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var us = db.Users.Find(id);
            if (us != null)
            {
                db.Users.Remove(us);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public User GetById(int idUser)
        {
            return db.Users.Find(idUser);
        }

        public User GetByUserName(String userName)
        {
            return db.Users.SingleOrDefault(x=>x.Username == userName);
        }

        public int login(string username, string password)
        {
            var rs = db.Users.SingleOrDefault(x => x.Username == username);
            if (rs == null)
            {
                return 0;
            }
            else
            {
                if(rs.Password == password)
                {
                    if (rs.Role == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }
    }
   
}
