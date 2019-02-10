using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetService.Models
{
    public class Sport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Competition> Competitions { get; set; }
    }
}
