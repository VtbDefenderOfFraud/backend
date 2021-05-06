using System.Threading.Tasks;
using AutoMapper;
using DefenderUiGateway.Data;
using DefenderUiGateway.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DefenderUiGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly DefenderDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserController(DefenderDbContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<User>> Get(int id)
        {
            var dbUser = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            var user = _mapper.Map<User>(dbUser);

            return user;
        }
    }
}