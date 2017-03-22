using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class UserControl
    {
        public static List<User> Users = new List<User>();

        public void AddUsers(User User)
        {
            Users.Add(User);
        }
        public void UserType(User User)
        {
            if (BLL.UserControl.Users.Count == 0)
            {
                User.UserType = eUserType.administrator;
            }
        } 
        //public void SaveUser(UserControl Users)
        //{
        //    DataManeger.DBData.Serialize(Users);
        //}
        //public UserControl GetBLUser()
        //{
        //    var DataUser = DataManeger.DBData.DeSerialize<UserControl>();
        //    return DataUser;
        //}
    }
}
