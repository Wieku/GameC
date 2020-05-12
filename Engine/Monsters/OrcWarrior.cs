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

        private int attacklessCounter = 0;
        
        // example monster: rat
        public OrcWarrior(int orcLevel)
        {
            Health = 70 + 5 * orcLevel;
            Strength = 13 + orcLevel * 3 / 2;
            Armor = 20;
            Precision = 40;
            MagicPower = 0;
            Stamina = 150;
            XPValue = 40 + 2 * orcLevel;
            Name = "monster2160";
            BattleGreetings = "You've come to a bad place...";
        }
        public override List<StatPackage> BattleMove()
        {
            if(Stamina > 0)
            {
                Stamina -= 50;
                if (Stamina <= 0)
                {
                    attacklessCounter = 3;
                }
                return new List<StatPackage>() { new StatPackage("stab", 11 + Strength, "Orc Warrior uses his club! ("+ (11 + Strength) +" hit damage)") };
            }
            else
            {
                --attacklessCounter;
                if (attacklessCounter <= 1)
                {
                    Stamina = 150;
                }
                return new List<StatPackage>() { new StatPackage("none", 0, "OrcWarrior has no energy to attack! He won't attack for " + attacklessCounter + " turns") };
            }
        }
    }
}
