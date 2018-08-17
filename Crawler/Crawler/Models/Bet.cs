using System;

namespace Crawler.Models
{
    public class Bet
    {
        public decimal Odd { get; set; }
        public string Name { get; set; }
        public decimal Percentage { get; set; }

        public override string ToString()
        {
            return $"Pari sur {Name} avec une cote de {Odd}. Pourcentage de mise sur ce pari {Percentage}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Bet comparedBet)
            {
                return decimal.Round(comparedBet.Odd, 2) == decimal.Round(Odd, 2) &&
                       comparedBet.Name == Name &&
                       decimal.Round(comparedBet.Percentage, 2) == decimal.Round(Percentage, 2);
            }
            
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0;
                result = (result * 397) ^ Odd.GetHashCode();
                result = (result * 397) ^ Name.GetHashCode();
                result = (result * 397) ^ Percentage.GetHashCode();
                return result;
            }
        }
    }
}