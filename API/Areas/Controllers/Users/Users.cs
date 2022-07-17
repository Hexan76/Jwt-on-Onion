using System.Collections.ObjectModel;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Service.InterfaceService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private readonly ISerRepUser _user;
        private readonly IAuth _auth;
        private readonly ICRUD _crud;
        private MainDBContext _dbContext;

        private readonly IMapper _mapping;

        public Users(ISerRepUser user, IAuth auth, ICRUD crud, MainDBContext dbContext, IMapper mapping)
        {
            _user = user;
            _auth = auth;
            _crud = crud;
            _dbContext = dbContext;
            _mapping = mapping;

        }
        UserResponse oResponse = new UserResponse(success: false, message: "Failed");

        [HttpPost]
        public Task<UserResponse> Create(UserCreateDTO user)
        {
            User oUser = _mapping.Map<UserCreateDTO, User>(user);
            return _user.CreateUserAsync(oUser);
        }
        [HttpGet]
        public Task<UserResponse> GetUserByUsernameAsync(string username)
        {
            return _user.GetUserbyUserNameAsync(username);
        }
        [HttpGet]
        public Task<UserResponse> GetUserByEmailAsync(string email)
        {
            return _user.GetUserByEmailAsync(email);
        }
        [HttpGet]
        public Task<UserResponse> AllUsers()
        {
            return _user.GetUsersAsync();
        }
        [HttpDelete]
        public Task<UserResponse> DeleteUserAsync(UserDeleteDTO user)
        {
            User oUser = _mapping.Map<UserDeleteDTO, User>(user);
            return _user.DeleteUserAsync(oUser);
        }

    }
}