using BookManagement.DataAccess.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DataAccess.Service
{
    public class ApplicationUserService : IApplicationUserService
    {
        private Dictionary<string, string> usersList;
        public ApplicationUserService()
        {
            usersList = new Dictionary<string, string>();
            for (int i = 1; i < 10; i++)
            {
                usersList.Add("user" + i.ToString(), "password" + i.ToString());
            }

            //usersList.Add("user1", "password1");
            //usersList.Add("user2", "password2");

            //string Name = usersList["user2"];//Password2
        }
        public bool Validate(string userId, string password)
        {
 //if (
            //    (userId == "subham" && password == "subham123") ||
            //    (userId == "deepti" && password == "deepti123") ||
            //    (userId == "deependra" && password == "deependra123") ||
            //    (userId == "pratik" && password == "pratik123") 
            //    )
            //{
            //    return true;
            //}
            //return false;
           

            if (usersList.ContainsKey(userId))
            {
                //string getpassword = usersList[userId];
                if (usersList[userId] == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
