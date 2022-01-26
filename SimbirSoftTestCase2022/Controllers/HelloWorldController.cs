using Microsoft.AspNetCore.Mvc;
using SimbirSoftTestCase2022.Services;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            WordService wordService = new WordService();
            
            return View(wordService.orderListByCount(wordService.getUniqueWordCount()));
        }
    }
}