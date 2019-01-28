using System.Collections.Generic;

namespace BetService.Models
{
    public class BetCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
