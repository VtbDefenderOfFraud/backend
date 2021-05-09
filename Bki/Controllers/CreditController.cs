using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bki.Data;
using Bki.Model.Controllers;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkCore.MemoryJoin;
using Microsoft.EntityFrameworkCore;

namespace Bki.Controllers
{
    // not using
    [ApiController]
    [Route("api/[controller]")]
    public class CreditController : ControllerBase
    {
        private readonly BkiDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreditController(BkiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("GetForUsersSince")]
        public async Task<IEnumerable<Credit>> GetForUsersSince(IList<UserCreditSince> request)
        {
            var userCreditSinceList = _dbContext.FromLocalList(request);

            var query = from credit in _dbContext.Credits.AsNoTracking()
                join userCreditSince in userCreditSinceList on credit.Passport equals userCreditSince.Passport
                where credit.Created > userCreditSince.Since
                select credit;

            var dbCredits = await query.ToListAsync();

            return _mapper.Map<IEnumerable<Credit>>(dbCredits);
        }
    }
}
