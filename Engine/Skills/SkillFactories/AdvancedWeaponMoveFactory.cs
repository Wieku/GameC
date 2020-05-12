using System;
using System.Collections.Generic;
using Game.Engine.Skills.BasicSkills;
using Game.Engine.CharacterClasses;
using Game.Engine.Skills.AdvancedWeaponMoves;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class AdvancedWeaponMoveFactory : SkillFactory
    {  
        // this factory produces skills from BasicSpells directory
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills); // check what spells from the BasicSpells category are known by the player already
            if (known == null) // no BasicSpells known - we will return one of them
            {
                SwordStab s1 = new SwordStab();
                SwordDance s2 = new SwordDance();
                LimbCut s3 = new LimbCut();
                // only include elligible spells
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (known.decoratedSkill == null) // an Advanced Weapon Move has been already learned, use decorator to create a combo
            {
                SwordStabDecorator s1 = new SwordStabDecorator(known);
                SwordDanceDecorator s2 = new SwordDanceDecorator(known);
                LimbCutDecorator s3 = new LimbCutDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else
            {
                SwordStabDecorator s1 = new SwordStabDecorator(known);
                SwordDanceDecorator s2 = new SwordDanceDecorator(known);
                LimbCutDecorator s3 = new LimbCutDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
        }
        private Skill CheckContent(List<Skill> skills) // wrapper method for checking
        {
            foreach (Skill skill in skills)
            {
                if (skill is SwordStab || skill is SwordDance || skill is LimbCut || skill is SwordStabDecorator || skill is SwordDanceDecorator || skill is LimbCutDecorator) return skill;
            }
            return null;
        }       

    }
}
