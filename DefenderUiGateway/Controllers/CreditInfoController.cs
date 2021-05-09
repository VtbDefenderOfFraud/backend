using System.Collections.Generic;
using System.Linq;
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
    public class CreditInfoController : ControllerBase
    {
        private readonly DefenderDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreditInfoController(DefenderDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditInfoItem>>> Get(int userId, int skip = 0, int take = 10)
        {
            var dbCredits =
                await _dbContext.Credits
                    .Include(x => x.Bank)
                    .Where(x => x.UserId == userId)
                    .Skip(skip)
                    .Take(take)
                    .OrderByDescending(c => c.InActionSince)
                    .ToListAsync();

            var creditInfos = _mapper.Map<IEnumerable<CreditInfoItem>>(dbCredits);

            return Ok(creditInfos);
        }
    }
}