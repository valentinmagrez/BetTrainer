using System.ComponentModel.DataAnnotations;

namespace Crawler.ViewModels
{
    public class UriBetsToParseViewModel
    {
        [Required]
        [Url]
        [Display(Name = "Url to parse")]
        public string UrlToParse { get; set; }

        public override string ToString()
        {
            return UrlToParse;
        }
    }
}
