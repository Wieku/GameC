using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class OrcShaman : Monster
    {

        private int playerLevel;
        private bool wasSpared = true;
        
        public OrcShaman(int playerLevel)
        {
            this.playerLevel = playerLevel;
            Health = 70 + 5 * playerLevel;
            Strength = 15 * playerLevel;
            Armor = 40;
            Precision = 80;
            MagicPower = 20 + 20 * playerLevel / 2;
            Stamina = 150;
            XPValue = 40 + 4 * playerLevel;
            Name = "monster2161";
            BattleGreetings = playerLevel < 3 ? "I hate to dominate weaklings, I will show you my mercy" : "I won't go easy for you";
        }
        public override List<StatPackage> BattleMove()
        {
            if (wasSpared && playerLevel < 3 && Index.RNG(0, 2) == 0)
            {
                Health = 0;
                return new List<StatPackage>() { new StatPackage("none", 0, "Orc Shaman has spared your miserable life") };
            }
            
            wasSpared = false;
            
            if(Stamina > 0)
            {
                Stamina -= 30;

                var packages = new List<StatPackage>() 
                {
                    new StatPackage("fire", MagicPower, "Orc Shaman uses his Shooting Dragon spell! ("+ (MagicPower) +" hit damage)")
                };

                if (Stamina > 20)
                {
                    bool useDragonsRoar = Index.RNG(0, 3) == 0;

                    if (useDragonsRoar)
                    {
                        Stamina -= 20;
                        packages.Add(new StatPackage("fire", MagicPower / 2, "Orc Shaman was quick and also used his Dragon's Roar spell! ("+ (MagicPower / 2) +" hit damage)"));
                    }
                }
                
                return packages;
            }
            else
            {
                bool potion = Index.RNG(1, playerLevel + 1) > playerLevel / 3;
                if (potion)
                {
                    Stamina += 150;
                }
                
                return new List<StatPackage>()
                {
                    new StatPackage("stab", Strength, "Orc Shaman has no enough mana to attack so he used his staff ("+ Strength +" hit damage)" + (potion ? ", also he used mana potion and restored some of it!" : ""))
                };
            }
        }
    }
}
