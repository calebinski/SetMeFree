using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetMeFree.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
