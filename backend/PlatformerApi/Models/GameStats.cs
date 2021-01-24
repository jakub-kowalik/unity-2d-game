using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformerApi.Models
{
    public class GameStats
    {
        public GameStats(long id, string playerName, int points, int level)
        {
            Id = id;
            PlayerName = playerName;
            Points = points;
            Level = level;
        }
        public GameStats()
        {

        }

        public long Id { get; set; }
        public string PlayerName { get; set; }
        public int Points { get; set; }
        public int Level { get; set; }
    }
}
