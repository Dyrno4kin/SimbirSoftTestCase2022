using HtmlAgilityPack;
using NLog;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace SimbirSoftTestCase2022.Services
{
    public class HtmlParserService
    {
        private Logger logger;

        public HtmlParserService()
        {
            logger = LogManager.GetCurrentClassLogger();
        }


        /// <summary>
        /// Метод, который убирает html разметку страницы, оставляя только текст
        /// </summary>
        /// <param name="htmlText">Исходный код страницы</param>
        /// <returns></returns>
        public string GetTextPage(string htmlText)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlText);

            var textString = doc.DocumentNode.InnerText;
            textString = Regex.Replace(textString, @"<(.|n)*?>", string.Empty).Replace("&nbsp", "").Replace('"', ' ').Replace("'", " ").Replace(">", " ").ToLower();
            return textString;
        }

        /// <summary>
        /// Метод, который получает html код заданной страницы
        /// </summary>
        /// <param name="url"> URL адрес страницы, которую требуется получить</param>
        /// <returns>Html код полученной страницы</returns>
        public string GetHtmlTextPage(string url)
        {
            var result = String.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString: url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseStream = response.GetResponseStream();
                    if (responseStream != null)
                    {
                        StreamReader streamReader;
                        if (response.CharacterSet != null)
                            streamReader = new StreamReader(responseStream, Encoding.GetEncoding(response.CharacterSet));
                        else
                            streamReader = new StreamReader(responseStream);
                        result = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                    response.Close();
                }
                return result;
            }
            catch
            {
                logger.Warn("Не удалось получить данные с сайта {0}", url);
                throw new Exception("Не удалось получить данные с сайта");
            }      
        }

        /// <summary>
        /// Метод, который разбивает строку на слова по заданному списку разделителей
        /// </summary>
        /// <param name="inputText">Входная строка</param>
        /// <returns>Массив слов</returns>
        public string[] SplitText(string inputText)
        {
            return Regex.Split(inputText, @"[\\s., !?;:<>|{}()\t\n\r\f]+");          
        }
    }
}
