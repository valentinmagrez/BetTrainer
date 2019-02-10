using System.ComponentModel.DataAnnotations.Schema;

namespace BetService.Models
{
    public class Competition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public Sport Sport { get; set; }
    }
}