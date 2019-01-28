namespace BetService.Models
{
    public class Bet
    {
        public long Id { get; set; }
        public decimal Odd { get; set; }
        public string Name { get; set; }
        public decimal Percentage { get; set; }
        public BetCategory BetCategory { get; set; }
    }
}
