using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetService.Models
{
    public class Bet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public decimal Odd { get; set; }
        public string Name { get; set; }
        public decimal Percentage { get; set; }

        public BetCategory BetCategory { get; set; }
        public Event Event { get; set; }
    }
}
