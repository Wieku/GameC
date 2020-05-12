using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items.Swords
{
    [Serializable]
    class Anferthe : Sword
    {
        public Anferthe() : base("item2163") 
        {
            StrMod = 100;
            PrMod = 20;
            StaMod = 80;
            GoldValue = 4000;
            PublicName = "An'ferthe"; 
        }

        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.StrengthBuff += currentPlayer.Level * 10;
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "stab" || pack.DamageType == "incised")
            {
                var crit = Index.RNG(0, 20) == 0; //5% critical chance

                if (crit) pack.HealthDmg = (int)(pack.HealthDmg * (1f + Index.RNG(20, 51) / 100f)); //20-50% more damage
            }

            return pack;
        }
    }
}
