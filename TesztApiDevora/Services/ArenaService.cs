using TesztApiDevora.Classes;
using TesztApiDevora.Enums;

namespace TesztApiDevora.Services
{
    public interface IArenaService
    {
        Guid GenerateRandomFighters(int numberOfHeroes);
        Arena SimulateBattle(Guid arenaId);
    }
    public class ArenaService :IArenaService
    {
        private readonly List<Arena> _arenas = new();

        public Guid GenerateRandomFighters(int numberOfHeroes)
        {
            var arena = new Arena();

            var rnd = new Random();

            //véletlenszerűen generáljuk a harcosok típusát:
            for (int i = 0; i < numberOfHeroes; i++)
            {
                int random = rnd.Next(1, 4);

                if (random == 1)
                {
                    Archer a = new Archer(i);
                    arena.Fighters.Add(a);
                }

                if (random == 2)
                {
                    Cavalry c = new Cavalry(i);
                    arena.Fighters.Add(c);
                }

                if (random == 3)
                {
                    SwordsMan s = new SwordsMan(i);
                    arena.Fighters.Add(s);
                }
            }
            _arenas.Add(arena);
            return arena.Id;
        }

        public Arena SimulateBattle(Guid arenaId)
        {
            //megkeressük az arénát
            var arena = _arenas.FirstOrDefault(a => a.Id == arenaId);
            if (arena == null)
                throw new ArgumentException("Érvénytelen aréna ID");

            int roundNumber = 1;
            var rand = new Random();

            //indul a while ciklus,addig fut amíg van élő harcos
            while (arena.Fighters.Count(h => h.IsAlive) > 1)
            {
                var attackers = arena.Fighters.Where(h => h.IsAlive).OrderBy(_ => rand.Next()).ToList();
                var attacker = attackers.First();
                var defender = attackers.Last();

                SimulateAttack(attacker, defender);

                arena.BattleHistory.Add(new BattleRound
                {
                    RoundNumber = roundNumber++,
                    AttackerId = attacker.Id,
                    DefenderId = defender.Id,
                    AttackerHealthAfter = attacker.Health,
                    DefenderHealthAfter = defender.Health
                });

                foreach (var fighter in arena.Fighters.Where(f => f.IsAlive && f != attacker && f != defender))
                {
                    switch (fighter.Type)
                    {
                        case FighterTypeEnum.Archer:
                            fighter.Health = Math.Min(fighter.Health + 10, 100);
                            break;
                        case FighterTypeEnum.SwordsMan:
                            fighter.Health = Math.Min(fighter.Health + 10, 120);
                            break;
                        case FighterTypeEnum.Cavalry:
                            fighter.Health = Math.Min(fighter.Health + 10, 150);
                            break;   
                    }                   
                }
            }
            return arena;
        }

        private void SimulateAttack(Fighter attacker, Fighter defender)
        {
            var rnd = new Random();
            switch (attacker.Type)
            {
                case FighterTypeEnum.Archer:
                    //lovast: 40% eséllyel a lovas meghal, 60%-ban kivédi
                    if (defender.Type == FighterTypeEnum.Cavalry)
                    {
                       int chance = rnd.Next(1, 101);
                       if (chance <= 40)
                       {
                           defender.Health = 0;
                       }                    
                    }

                    //íjászt: védekező meghal || kardost: kardos meghal
                    else if (defender.Type == FighterTypeEnum.SwordsMan || defender.Type == FighterTypeEnum.Archer)
                    {
                        defender.Health = 0;
                    }
                    break;

                case FighterTypeEnum.SwordsMan:
                    //lovast: nem történik semmi
                    if (defender.Type == FighterTypeEnum.Cavalry)
                    {
                        //védőnek nincs sebződése
                    }
                    //íjászt: íjász meghal || // kardost: védekező meghal
                    else if (defender.Type == FighterTypeEnum.Archer || defender.Type == FighterTypeEnum.SwordsMan)
                    {
                        defender.Health = 0;
                    }
                    break;
                
                case FighterTypeEnum.Cavalry:
                    //íjászt: íjász meghal
                    if (defender.Type == FighterTypeEnum.Archer)
                    {
                        defender.Health = 0;
                    }

                    //lovast: védekező meghal
                    else if (defender.Type == FighterTypeEnum.Cavalry)
                    {
                        defender.Health = 0;
                    }

                    // kardost: lovas meghal
                    else if (defender.Type == FighterTypeEnum.SwordsMan)
                    {
                        //lovas hal meg!!!!
                        attacker.Health = 0;
                    } 
                    break;
            }

            if (attacker.Health <= attacker.Health / 4)
            {
                attacker.Health = 0;
            }
            else
            {
                attacker.Health /= 2;
            }
        }

    }
}
