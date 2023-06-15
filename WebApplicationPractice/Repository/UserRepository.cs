using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationPractice.Model;

namespace WebApplicationPractice.Repository
{
    public class UserRepository: IUserRepository
    {
        public List<User> createUserList() {

            List<User> user = new List<User>() {
                new User() {
                       Id = 1,
                       firstName="Lauren",
                       lastName = "Qie",
                       email= "lauren.qz11@gmail.com"
                },

                new User()
                {
                    Id = 2,
                    firstName = "Steven",
                    lastName = "Yu",
                    email = "stevenyu@gmail.com"
                }

                };

            return user;
        
        }
    }
}
