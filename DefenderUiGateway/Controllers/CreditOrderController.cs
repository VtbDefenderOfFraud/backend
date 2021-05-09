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
    public class CreditOrderController : ControllerBase
    {
        private readonly DefenderDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreditOrderController(DefenderDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditOrder>>> Get(int userId, int skip = 0, int take = 10)
        {
            var dbCreditRequests =
                await _dbContext.CreditRequests
                    .Include(x => x.Bank)
                    .Where(x => x.UserId == userId)
                    .Skip(skip)
                    .Take(take)
                    .OrderByDescending(r => r.OrderDate)
                    .ToListAsync();

            var creditOrders = _mapper.Map<IEnumerable<CreditOrder>>(dbCreditRequests);

            return Ok(creditOrders);
        }
    }
}