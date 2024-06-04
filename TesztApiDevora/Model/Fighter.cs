using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesztApiDevora.Enums;

namespace TesztApiDevora.Classes
{
    public class Fighter
    {
        public int Health { get; set; } 

        public int Id { get; set; }
    
        public FighterTypeEnum Type { get; set; }

        public bool IsAlive => Health > 0;

    }

   public class Archer : Fighter 
   {
        public Archer(int id)
        {
            Id = id;
            Health = 100;
            Type = FighterTypeEnum.Archer;
        }
   }

    public class Cavalry : Fighter
    {
        public Cavalry(int id)
        {
            Id = id;
            Health = 150;
            Type = FighterTypeEnum.Cavalry;
        }    
    }

    public class SwordsMan : Fighter
    {
        public SwordsMan(int id)
        {
            Id = id;
            Health = 120;
            Type = FighterTypeEnum.SwordsMan;
        }    
    }

}
