using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponMoves
{

    [Serializable]
    class SwordStabDecorator : SkillDecorator
    {
        
        public SwordStabDecorator(Skill skill) : base("Sword Stab", 30, 3, skill)
        { 
            MinimumLevel = Math.Max(8, skill.MinimumLevel) + 1;
            PublicName = "COMBO: Basic spear stab [requires sword]: 0.2*Str + 0.3*Pr damage [stab] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = "Sword";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("stab");
            response.HealthDmg = (int)(0.2 * player.Strength) + (int)(0.3 * player.Precision);
            response.CustomText = "You use Sword Stab! (" + ((int)(0.2 * player.Strength) + (int)(0.3 * player.Precision)) + " stab damage)";

            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
    
}
