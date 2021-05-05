using Bki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Bki.Data;

namespace Bki.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BkiDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, BkiDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        [HttpPost]
        public async Task<IActionResult> Index(string passport, int amount)
        {
            _dbContext.Add(new LoanRequest(passport, amount));

            await _dbContext.SaveChangesAsync();

            return Content("ok");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel
            {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
