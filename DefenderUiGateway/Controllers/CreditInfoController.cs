using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DefenderUiGateway.Model;
using Microsoft.AspNetCore.Mvc;

namespace DefenderUiGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditInfoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditInfoItem>>> Get()
        {
            var creditInfos = new List<CreditInfoItem>
            {
                new("СберБанк", 200000, 50000, DateTime.Now.AddDays(-5), CreditState.Closed),
                new("СберБанк", 500000, 45000, DateTime.Now.AddDays(-3), CreditState.Active),
                new("Тинькофф", 150000, 3000, DateTime.Now.AddDays(-2), CreditState.Active)
            };

            return Ok(creditInfos);
        }
    }
}
