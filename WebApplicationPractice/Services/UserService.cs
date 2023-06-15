using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationPractice.Model;
using WebApplicationPractice.Repository;

namespace WebApplicationPractice.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }

        public void CreateUser(User user) {
            var userList = _userRepository.createUserList();
            userList.Add(user);
        }

        public User GetUserById(int id) {

            var userList = _userRepository.createUserList();
            var user = userList.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public void UpdateUser(int id, User user) {
            var userList = _userRepository.createUserList();
            var userOld = userList.FirstOrDefault(u => u.Id == id);
            userOld.firstName = user.firstName;
            userOld.lastName = user.lastName;
            userOld.email = user.email; 
        }

        public void DeleteUser(int id)
        {
            var userList = _userRepository.createUserList();
            var user = userList.FirstOrDefault(u => u.Id == id);
            userList.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            var userList = _userRepository.createUserList();
            return userList;
        }
    }
}
