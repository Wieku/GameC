using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponMoves
{

    [Serializable]
    class SwordDanceDecorator : SkillDecorator
    {
        
        public SwordDanceDecorator(Skill skill) : base("Sword Dance", 40, 4, skill)
        { 
            MinimumLevel = Math.Max(4, skill.MinimumLevel) + 1;
            PublicName = "COMBO: Small 5 consecutive cuts like sword dancer, dealing 0.2*Str per hit [requires sword] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = "Sword";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            var responses = new List<StatPackage>();

            for (int i = 0; i < 5; i++)
            {
                StatPackage response = new StatPackage("incised");
                if (Index.RNG(0, 100) < player.Precision)
                {
                    response.HealthDmg = (int)(0.2 * player.Strength);
                    response.CustomText = "Fast slash! (" + (int)(0.2 * player.Strength) + " incision damage)";
                }
                else
                {
                    response.HealthDmg = 0;
                    response.CustomText = "You should be aiming better!";
                }
                responses.Add(response);
            }

            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.AddRange(responses);
            return combo;
        }
    }
}
