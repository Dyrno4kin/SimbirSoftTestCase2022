using System.ComponentModel.DataAnnotations;

namespace SimbirSoftTestCase2022.Models
{
    public class Statistics
    {
        public int Id { get; set; }

        [Display(Name = "Сайт")]
        public string Name { get; set; }

        [Display(Name = "Количество слов")]
        public int CountWords { get; set; }

        [Display(Name = "Количество уникальных слов")]
        public int CountUniqueWords { get; set; }

        [Display(Name = "Дата обращения")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
