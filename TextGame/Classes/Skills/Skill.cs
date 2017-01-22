namespace Game.Skills
{
    using System;

    public abstract class Skill
    {
        public static Skill GetSkillInstance(string skillName)
        {
            // Get the type of the skill.
            var skillType = Type.GetType("Game.Skills." + skillName);

            // Create a new instance of the skill
            var skillInstance = (Skill)Activator.CreateInstance(skillType);

            return skillInstance;
        }
    }
}
