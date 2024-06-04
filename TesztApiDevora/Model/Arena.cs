using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesztApiDevora.Classes
{
    public class Arena
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Fighter> Fighters { get; set; } = new List<Fighter>();
        public List<BattleRound> BattleHistory { get; set; } = new List<BattleRound>();

    }
}
