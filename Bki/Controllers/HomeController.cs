using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Bki.Data;
using Bki.Model;
using Bki.Model.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Credit = Bki.Model.UI.Credit;

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

        public async Task<IActionResult> Index()
        {
            var banks = await _dbContext.Banks.AsNoTracking().ToListAsync();

            ViewBag.Banks = new SelectList(banks, nameof(Bank.Id), nameof(Bank.Name));

            return View();
        }

        public IActionResult Privacy() => View();

        [HttpPost]
        public async Task<IActionResult> Index(Credit request)
        {
            _dbContext.Add(new Model.Data.Credit(request.BankId, request.Passport, request.Amount));

            await _dbContext.SaveChangesAsync();

            return Content("ok");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel
            {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}