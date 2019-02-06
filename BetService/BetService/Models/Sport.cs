using System.Collections.Generic;

namespace BetService.Models
{
    public class Sport
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Competition> Competitions { get; set; }
    }
}
