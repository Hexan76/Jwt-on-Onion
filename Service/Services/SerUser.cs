using Repository.Interfaces;
using Repository.Repository;
using Service.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SerUser : ISerRepUser
    {
        private IUser _user;
        private readonly IPasswordHasher _hashPass;

        public SerUser(IUser user, IPasswordHasher hashPass)
        {
            _user = user;
            _hashPass = hashPass;
        }

        public async Task<UserResponse> CreateUserAsync(User user)
        {
            var existingUser = _user.Find(user.ID);
            if (existingUser != null) return new UserResponse(false, "User is Exist");
            user.Password = _hashPass.HashPassword(user.Password);
            await Task.FromResult(_user.Create(user));
            return new UserResponse(true, "User Created", user);
        }

        public async Task<UserResponse> GetUserByEmailAsync(string email)
        {
            var existingUser = await Task.FromResult(_user.FindByEmail(email));
            if (existingUser == null) return new UserResponse(false, "User not Found");
            return new UserResponse(true, "User Founded", existingUser);
        }

        public async Task<UserResponse> GetUserByGUIDAsync(Guid guid)
        {
            var existingUser = await Task.FromResult(_user.Find(guid));
            if (existingUser == null) return new UserResponse(false, "User not Found");
            return new UserResponse(true, "User Founded", existingUser);
        }

        public async Task<UserResponse> GetUserbyUserNameAsync(string userName)
        {
            var existingUser = await Task.FromResult(_user.Find(userName));
            if (existingUser == null) return new UserResponse(false, "User not Found");
            return new UserResponse(true, "User Founded", existingUser);
        }

        public async Task<UserResponse> GetUsersAsync()
        {
            var existingUsers = await Task.FromResult(_user.GetAll());
            if (existingUsers.Count == 0) return new UserResponse(false, "Users not Found");
            return new UserResponse(true, "Users Founded", null, existingUsers);
        }
        public async Task<UserResponse> GetUsersByPageAsync(int pagesize = 10, int pageindex = 1)
        {
            var existingUsers = await Task.FromResult(_user.GetPageList(pagesize, pageindex));
            if (existingUsers.Count == 0) return new UserResponse(false, "User not Found");
            return new UserResponse(true, "Users Founded and returned as list", null, existingUsers);
        }

        public async Task<UserResponse> DeleteUserAsync(User user)
        {
            var existingUser = await Task.FromResult(_user.Find(user.UserName));
            if (existingUser == null) return new UserResponse(false, "User not Found");
            await Task.FromResult(_user.Delete(user));
            return new UserResponse(true, "User Deleted", existingUser);
        }

        public async Task<UserResponse> DeleteUserByGuidAsync(Guid guiduser)
        {
            var existingUser = await Task.FromResult(_user.Find(guiduser));
            if (existingUser == null) return new UserResponse(false, "User not Found");
            await Task.FromResult(_user.Delete(guiduser));
            return new UserResponse(true, "User Deleted", existingUser);
        }

        public async Task<UserResponse> DeleteUserByEmailAsync(string email)
        {
            var existingUser = await Task.FromResult(_user.FindByEmail(email));
            if (existingUser == null) return new UserResponse(false, "User not Found");
            await Task.FromResult(_user.Delete(existingUser));
            return new UserResponse(true, "User Deleted", existingUser);
        }
    }
}
