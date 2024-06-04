using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesztApiDevora.Classes
{
    public class BattleRound
    {
        public int RoundNumber { get; set; }
        public int AttackerId { get; set; }
        public int DefenderId { get; set; }
        public int AttackerHealthAfter { get; set; }
        public int DefenderHealthAfter { get; set; }
    }
}
