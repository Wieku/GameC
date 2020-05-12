using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponMoves
{
    [Serializable]
    class SwordDance : Skill
    {
        
        public SwordDance() : base("Sword Dance", 40, 4)
        { 
            PublicName = "Small 5 consecutive cuts like sword dancer, dealing 0.2*Str per hit [requires sword]";
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

            return responses;
        }
    }
}
