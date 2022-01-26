using SimbirSoftTestCase2022.Models;
using System.Linq;

namespace SimbirSoftTestCase2022.Services
{
    public class WordService
    {
        public List<Word> getUniqueWordCount(string[] splitString)
        {
            //string[] weekDays = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun", "Mon", "Wed", "Wed", "Wed" };
            List<Word> words = new List<Word>();
            foreach (String str in splitString)
            {
                var word = words.FirstOrDefault(w => w.Name == str);
                if (word != null)
                {
                    word.Count += 1;
                }
                else
                {
                    words.Add(new Word { Name = str, Count = 1 });
                }
            }
            return words;
        }

        public List<Word> orderListByCount(List<Word> words)
        {
            return words.OrderByDescending(word => word.Count).ToList();
        }

        public int getTotalWordCount(List<Word> words)
        {
            return words.Sum(x => x.Count);
        }

        public Word getMostFrequentWord(List<Word> words)
        {
            return words.OrderByDescending(word => word.Count).First();
        }
    }
}
