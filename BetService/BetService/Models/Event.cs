using System;
using System.Collections.Generic;

namespace BetService.Models
{
    public class Event
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
