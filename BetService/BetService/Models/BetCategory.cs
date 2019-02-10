using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetService.Models
{
    public class BetCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
