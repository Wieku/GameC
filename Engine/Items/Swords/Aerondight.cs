using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Swords
{
    [Serializable]
    class Aerondight : Sword
    {
        private float attackBonus = 0f;
        // simple sword
        public Aerondight() : base("item2162") 
        {
            StrMod = 200;
            PrMod = 20;
            StaMod = 100;
            GoldValue = 10000;
            PublicName = "Aerondight"; 
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "stab" || pack.DamageType == "incised")
            {
                pack.HealthDmg = (int)(pack.HealthDmg * (1f + attackBonus));

                attackBonus = Math.Min(1f, attackBonus + 0.1f);
            }

            return pack;
        }
    }
}
