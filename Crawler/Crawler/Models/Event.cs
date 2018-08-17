using System;
using System.Collections.Generic;
using System.Linq;

namespace Crawler.Models
{
    public class Event
    {
        public string CompetitionName { get; set; }
        public string Name { get; set; }
        public string BetType { get; set; }
        public string Sport { get; set; }
        public DateTime StartDate { get; set; }
        public IList<Bet> BetAvailables { get; set; }

        public override string ToString()
        {
            return $"{Sport} - {CompetitionName} - {BetType} - {Name} - {StartDate} - {Environment.NewLine} {string.Join(",", BetAvailables.Select(x => x.ToString()+ Environment.NewLine).ToArray())}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Event comparedBet)
            {
                return comparedBet.CompetitionName == CompetitionName &&
                       comparedBet.Name == Name &&
                       comparedBet.BetType == BetType &&
                       comparedBet.Sport == Sport &&
                       comparedBet.StartDate == StartDate &&
                       comparedBet.BetAvailables.SequenceEqual(BetAvailables);
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0;
                result = (result * 397) ^ CompetitionName.GetHashCode();
                result = (result * 397) ^ Name.GetHashCode();
                result = (result * 397) ^ BetType.GetHashCode();
                result = (result * 397) ^ Sport.GetHashCode();
                result = (result * 397) ^ StartDate.GetHashCode();
                result = (result * 397) ^ BetAvailables.GetHashCode();
                return result;
            }
        }

    }
}