using ContactApp.Models;

namespace ContactApp.Repositories
{


    internal class UserRepository
    {
        private List<User> _users = new List<User>();



        public UserRepository()
        {
            _users.Add(new User { UserId = 1, FName = "Admin", LName = "User", IsAdmin = true });
            _users.Add(new User { UserId = 2, FName = "Staff", LName = "Member", IsAdmin = false });
        }




        public User GetUserById(int userId)
        {
            var users = _users.FirstOrDefault(u => u.UserId == userId);
            return users;
        }


        public void AddUser(User user)
        {
            _users.Add(user);
        }



        public void UpdateUser(User user)
        {
            var existingUser = GetUserById(user.UserId);
            if (existingUser != null)
            {
                existingUser.FName = user.FName;
                existingUser.LName = user.LName;
                existingUser.IsActive = user.IsActive;
            }
        }


        public void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                user.IsActive = false;
            }
        }



        public List<User> GetAllUsers()
        {
            var users = _users.Where(x => x.IsActive).ToList();
            return users;
        }
    }

}
