using HtmlAgilityPack;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace SimbirSoftTestCase2022.Services
{
    public class HtmlParserService
    {


        public string getTextPage(string url)
        {
            var result = String.Empty;
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
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(result);

            var textString = doc.DocumentNode.InnerText;
            textString = Regex.Replace(textString, @"<(.|n)*?>", string.Empty).Replace("&nbsp", "").Replace('"', ' ').Replace("'", " ").Replace(">", " ").ToLower();
            return textString;
        }

        public string[] splitText(string inputText)
        {
            return Regex.Split(inputText, @"[\\s., !?;:<>|{}()\t\n\r\f]+");          
        }


    }
}
