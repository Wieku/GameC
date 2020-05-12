using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponMoves
{
    [Serializable]
    class LimbCut : Skill
    {
        
        public LimbCut() : base("Limb Cut", 120, 8)
        { 
            PublicName = "Limb Cut, dirty move, dealing 0.4*Str health damage + 0.3*Pr strength damage [requires sword]";
            RequiredItem = "Sword";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            var response = new StatPackage("incised");
            response.HealthDmg += (int)(0.4 * player.Strength);
            response.StrengthDmg += (int)(0.3 * player.Precision);
            response.CustomText = "You use Limb Cut! (" + (int)(0.4 * player.Strength) + " incision damage and  "+ (int)(0.3 * player.Precision) + " strength damage)";

            return new List<StatPackage>() { response };
        }
    }
}
