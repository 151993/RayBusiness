using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tectoro_Task.Models;

namespace Tectoro_Task.Repository
{
   public interface IPostRepository
    {
        public List<Users> GetUsers();

        public Users AddUser(Users user);

        public Task UpdateUser(Users user);

        public Task<int> DeleteUser(int id);
        public List<Helper> GetDetails();
        public List<Helper> ClientManagerDetails();
        public List<Helper> GetManagerAllClients(string userName);
    }
}
