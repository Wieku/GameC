using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class OrcWarrior : Monster
    {
        
        public OrcWarrior(int orcLevel)
        {
            Health = 70 + 5 * orcLevel;
            Strength = 13 + orcLevel * 3 / 2;
            Armor = 20;
            Precision = 40;
            MagicPower = 0;
            Stamina = 300;
            XPValue = 40 + 2 * orcLevel;
            Name = "monster2160";
            BattleGreetings = "You've come to a bad place...";
        }
        public override List<StatPackage> BattleMove()
        {
            if(Stamina > 100)
            {
                Stamina -= 50;
                return new List<StatPackage>() { new StatPackage("stab", 11 + Strength, "Orc Warrior uses his club! ("+ (11 + Strength) +" stab damage)") };
            }
            else if(Stamina > 0)
            {
                Stamina -= 100;
                return new List<StatPackage>() { new StatPackage("stab", 11 + (int)(Strength * 1.4), "Orc Warrior throws his club! ("+ (11 + (int)(Strength * 1.4)) +" stab damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage("none", 0, "OrcWarrior has no energy to attack!") };
            }
        }
    }
}
