using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponMoves
{

    [Serializable]
    class LimbCutDecorator : SkillDecorator
    {
        
        public LimbCutDecorator(Skill skill) : base("Limb Cut", 120, 8, skill)
        { 
            MinimumLevel = Math.Max(8, skill.MinimumLevel) + 1;
            PublicName = "COMBO: Limb Cut, dirty move, dealing 0.4*Str health damage + 0.3*Pr strength damage [requires sword] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = "Sword";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            var response = new StatPackage("incised");
            response.HealthDmg += (int)(0.4 * player.Strength);
            response.StrengthDmg += (int)(0.3 * player.Precision);
            response.CustomText = "You use Limb Cut! (" + (int)(0.4 * player.Strength) + " incision damage and  "+ (int)(0.3 * player.Precision) + " strength damage)";

            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
    
}
