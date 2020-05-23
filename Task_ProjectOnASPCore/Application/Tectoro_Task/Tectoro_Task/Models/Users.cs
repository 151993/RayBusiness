using System;
using System.Collections.Generic;

namespace Tectoro_Task.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Alias { get; set; }
        public string Type { get; set; }
        public string Position { get; set; }
        public int? ManagerId { get; set; }
        //public string Manager { get; internal set; }
        //public string Client { get; internal set; }
    }
}
