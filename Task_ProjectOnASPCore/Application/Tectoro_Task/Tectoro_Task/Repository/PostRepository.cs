using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Tectoro_Task.Models;

namespace Tectoro_Task.Repository
{
    public class PostRepository : IPostRepository
    {
        //private List<Users> _users;
        DomainContext _users;
        public PostRepository(DomainContext user)
        {
            _users = user;
        }
        //public PostRepository()
        //{
        //    _users = new List<Users>();
        //}

        public List<Users> GetUsers()
        {
            var data = _users.Users.ToList();
            return data;
        }

        public Users AddUser(Users user)
        {
            _users.Add(user);
            return user;
        }

        public async Task UpdateUser(Users user)
        {
            if (_users != null)
            {
                //Delete that post
                _users.Users.Update(user);

                //Commit the transaction
                await _users.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteUser(int id)
        {
            int result = 0;

            if (_users != null)
            {
                //Find the post for specific post id
                var post = _users.Users.FirstOrDefault(x => x.UserId == id);

                if (post != null)
                {
                    //Delete that post
                    _users.Users.Remove(post);

                    //Commit the transaction
                    result = await _users.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }
        public List<Helper> GetDetails()
        {
            List<Helper> query = (from r in _users.Users
                                  join q in _users.Users on r.UserId equals q.ManagerId
                                  select new Helper
                                  {
                                      Manager = r.FirstName + " " + r.LastName,
                                      Client = q.FirstName + " " + q.LastName
                                  }).ToList();
            return query;


            //List<string> query1 = new List<string>();
            //var query = (from r in _users.Users
            //             join q in _users.Users on r.UserId equals q.ManagerId
            //             select new SelectListItem
            //             {
            //                 Value = r.FirstName + " " + r.LastName,
            //                 Text = q.FirstName + " " + q.LastName
            //             }).ToList();
            //foreach (var item in query)
            //{
            //    query1.Add("Manager: "+item.Value + ", " + "Client: "+item.Text);
            //}
            //  return query;

        }
        public List<Helper> GetManagerAllClients(string userName)
        {
            var item = _users.Users.Where(u => u.UserName == userName).Select(u =>u.UserId ).FirstOrDefault();
            int userId = Convert.ToInt32(item);
            List<Helper> query = (from r in _users.Users
                                  join q in _users.Users on r.UserId equals q.ManagerId
                                  where r.UserId==userId
                                  select new Helper
                                  {
                                      Manager = r.FirstName + " " + r.LastName,
                                      Client = q.FirstName + " " + q.LastName
                                  }).ToList();
            return query;
        }
        public List<Helper> ClientManagerDetails()
        {
            List<Helper> query = (from r in _users.Users
                                  join q in _users.Users on r.UserId equals q.ManagerId
                                  select new Helper
                                  {
                                      Manager = r.FirstName + " " + r.LastName,
                                      Client = q.FirstName + " " + q.LastName
                                  }).ToList();
            return query;

        }
    }
}
