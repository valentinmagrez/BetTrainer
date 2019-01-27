using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetService.Models
{
    public class Bet
    {
        public long Id { get; set; }
        public decimal Odd { get; set; }
        public string Name { get; set; }
        public decimal Percentage { get; set; }
    }
}
