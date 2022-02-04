using Microsoft.AspNetCore.Mvc;
using SimbirSoftTestCase2022.Data;
using SimbirSoftTestCase2022.Models;
using SimbirSoftTestCase2022.Services;

namespace MvcMovie.Controllers
{
    /// <summary>
    /// Класс для отображения статистики по конкретному сайту
    /// </summary>
    public class WebsiteStatisticsController : Controller
    {
        private readonly SimbirSoftTestCase2022Context _context;

        public WebsiteStatisticsController(SimbirSoftTestCase2022Context context)
        {
            _context = context;
        }


        // 
        // GET: /HelloWorld/
        /// <summary>
        /// Метод для отображения статистики по сайту
        /// </summary>
        /// <param name="searchString"> URL сайта, по которому требуется загрузить статистику</param>
        /// <returns></returns>
        public async Task<IActionResult> IndexAsync(string searchString = "https://www.simbirsoft.com/")
        {
            HtmlParserService htmlParserService = new HtmlParserService();
            var words = new List<WordViewModel>();
            if (!String.IsNullOrEmpty(searchString))
            {
                words = GetListUniqueWordCount(htmlParserService.SplitText(htmlParserService.GetTextPage(htmlParserService.GetHtmlTextPage(searchString)))).OrderByDescending(word => word.Count).ToList();
                
                ViewData["totalCountWords"] = "Всего слов: " + words.Sum(x => x.Count);
                ViewData["mostFrequentWord"] = "Самое частое слово: " + words.OrderByDescending(word => word.Count).First().Name;
                ViewData["measureText"] = "Мера лексического разнообразия: " + (double)words.Count() / (double)words.Sum(x => x.Count);
                Statistics statistics = new Statistics { Name = searchString, CountWords = words.Sum(x => x.Count), CountUniqueWords = words.Count(), Date = DateTime.Today };
                await _context.AddAsync(statistics);
                await _context.SaveChangesAsync();
            }
            return View(words);
        }


        /// <summary>
        /// Метод, который преобразует исходный массив слов в список уникальных слов с указанием частоты встречаемости каждого слова
        /// </summary>
        /// <param name="splitString">Исходный массив слов</param>
        /// <returns>Возвращает список уникальных слов</returns>
        private List<WordViewModel> GetListUniqueWordCount(string[] splitString)
        {
            List<WordViewModel> words = new List<WordViewModel>();
            foreach (String str in splitString)
            {
                var word = words.FirstOrDefault(w => w.Name == str);
                if (word != default)
                {
                    word.Count += 1;
                }
                else
                {
                    words.Add(new WordViewModel { Name = str, Count = 1 });
                }
            }
            return words;
        }
    }
}