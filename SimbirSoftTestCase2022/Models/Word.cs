using System.ComponentModel.DataAnnotations;

namespace SimbirSoftTestCase2022.Models
{
    public class Word
    {
        [Display(Name = "Слово")]
        public string Name { get; set; }

        [Display(Name = "Количество")]
        public int Count { get; set; }
    }
}
