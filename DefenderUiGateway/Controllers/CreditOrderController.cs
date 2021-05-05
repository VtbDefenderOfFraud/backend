using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DefenderUiGateway.Model;
using Microsoft.AspNetCore.Mvc;

namespace DefenderUiGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditOrderController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditOrder>>> Get()
        {
            var creditInfos = new List<CreditOrder>
            {
                new("СберБанк", "1234143124","3434343", DateTime.Now.AddDays(-5)),
                new("СберБанк", "1234143124","3434343", DateTime.Now.AddDays(-3)),
                new("Тинькофф", "4536556456","45645645", DateTime.Now.AddDays(-2))
            };

            return Ok(creditInfos);
        }
    }
}
