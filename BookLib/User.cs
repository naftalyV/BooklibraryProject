using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Flags]
    public enum eUserType
    {
        consumer,
        Employee,
        Administrator
    }
    [Serializable]

    public class User
    {
        public string id { get; set; }

        public string FirstName { get; set; }

        public string LastNama { get; set; }

        public DateTime BirthDate { get; set; }
      

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public string Adress { get; set; }
        public eUserType UserType { get; set; }
    }

}

