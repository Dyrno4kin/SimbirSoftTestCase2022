using Microsoft.AspNetCore.Mvc;
using SimbirSoftTestCase2022.Models;
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

        public IActionResult Welcome(string searchString = "https://www.simbirsoft.com/")
        {
            
            WordService wordService = new WordService();
            HtmlParserService htmlParserService = new HtmlParserService();
            var words = new List<Word>();
            if (!String.IsNullOrEmpty(searchString))
            {
                words = wordService.orderListByCount(wordService.getUniqueWordCount(htmlParserService.splitText(htmlParserService.getTextPage(searchString))));
                ViewData["totalCountWords"] = "Всего слов: " + wordService.getTotalWordCount(words);
                ViewData["mostFrequentWord"] = "Самое частое слово: " + wordService.getMostFrequentWord(words).Name;
                ViewData["measureText"] = "Мера лексического разнообразия: " + (double)words.Count()/(double)wordService.getTotalWordCount(words);
            }

            return View(words);
        }
    }
}