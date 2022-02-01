using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimbirSoftTestCase2022.Data;

namespace SimbirSoftTestCase2022.Controllers
{
    /// <summary>
    /// Класс для отображения статистики по количеству слов на разных сайтах
    /// </summary>
    public class StatisticsController : Controller
    {
        private readonly SimbirSoftTestCase2022Context _context;

        public StatisticsController(SimbirSoftTestCase2022Context context)
        {
            _context = context;
        }

        // GET: Statistics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Statistics.ToListAsync());
        }
      
    }
}
