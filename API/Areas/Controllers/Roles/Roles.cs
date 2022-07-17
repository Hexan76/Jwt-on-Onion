using System.Collections.ObjectModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Service.InterfaceService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Roles : ControllerBase
    {
        private readonly ISerRepUser _user;
        private readonly IAuth _auth;
        private readonly ICRUD _crud;
        private MainDBContext _dbContext;

        public Roles(ISerRepUser user, IAuth auth, ICRUD crud, MainDBContext dbContext)
        {
            _user = user;
            _auth = auth;
            _crud = crud;
            _dbContext = dbContext;
        }

    }
}