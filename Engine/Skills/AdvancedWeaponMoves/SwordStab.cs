using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponMoves
{
    [Serializable]
    class SwordStab : Skill
    {
        
        public SwordStab() : base("Sword Stab", 30, 3)
        { 
            PublicName = "Basic spear stab [requires sword]: 0.2*Str + 0.3*Pr damage [stab]";
            RequiredItem = "Sword";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("stab");
            response.HealthDmg = (int)(0.2 * player.Strength) + (int)(0.3 * player.Precision);
            response.CustomText = "You use Sword Stab! (" + ((int)(0.2 * player.Strength) + (int)(0.3 * player.Precision)) + " stab damage)";
            return new List<StatPackage>() { response };
        }
    }
}
