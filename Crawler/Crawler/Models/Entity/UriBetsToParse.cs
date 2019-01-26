using System.ComponentModel;

namespace Crawler.Models.Entity
{
    public class UriBetsToParse
    {
        public int Id { get; set; }
        [DisplayName("Nom")]
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
