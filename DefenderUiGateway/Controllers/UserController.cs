using System.Threading.Tasks;
using AutoMapper;
using DefenderUiGateway.Data;
using DefenderUiGateway.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DefenderUiGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
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

        [HttpPost("token")]
        public async Task<IActionResult> PostToken(PhoneToken phoneToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == phoneToken.UserId);
            if (user == null)
                return NotFound($"User with id {phoneToken.UserId} not found");
            user.Token = phoneToken.Token;
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return Ok();
        }
    }
}