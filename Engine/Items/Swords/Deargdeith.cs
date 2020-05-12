using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items.Swords
{
    [Serializable]
    class Deargdeith : Sword
    {
        public Deargdeith() : base("item2164") 
        {
            StrMod = 100;
            PrMod = 20;
            StaMod = 80;
            GoldValue = 6000;
            PublicName = "Deargdeith"; 
        }

        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.StrengthBuff += currentPlayer.Level * 20;
        }

        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "stab" || pack.DamageType == "incised")
            {
                if (Index.RNG(0, 20) == 0) //5% block chance
                    pack.HealthDmg = 0; //block completely
            }

            return pack;
        }
    }
}
