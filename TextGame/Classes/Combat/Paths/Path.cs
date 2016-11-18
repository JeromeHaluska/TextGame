namespace Game.Combat.Paths
{
    using System;
    using System.Collections.Generic;
    using Skills;

    public abstract class Path
    {
        public Path()
        {
            var pathJsonReader = new PathJsonReader(this);

            NameProgressionList = pathJsonReader.NameProgressionList;
            StartingSkillList = pathJsonReader.StartingSkillList;
            SkillProgressionList = pathJsonReader.SkillProgressionList;
        }

        /// <summary>
        /// The name of the path can change when the player level increases.
        /// The current path name is the last string that is stored at an index that is below or equal to the player level.
        /// </summary>
        protected string[] NameProgressionList { get; set; } = new string[100];

        /// <summary>
        /// The skills that are available from the start of the game.
        /// </summary>
        protected List<Skill> StartingSkillList { get; set; } = new List<Skill>();

        /// <summary>
        /// The skills that become available when the player level increases.
        /// All the skills which index in the array is lower or equal than the player level are useable.
        /// </summary>
        protected Skill[] SkillProgressionList { get; set; } = new Skill[100];

        /// <summary>
        /// Returns all skills that are currently to the player available.
        /// </summary>
        /// <param name="playerLevel">Current player level</param>
        /// <returns></returns>
        public List<Skill> GetUsableSkills(int playerLevel)
        {
            List<Skill> useableSkills = new List<Skill>();
            if (StartingSkillList != null) {
                foreach (Skill skill in StartingSkillList) {
                    useableSkills.Add(skill);
                }
            }
            for (int cnt = 0; cnt < Math.Min(playerLevel, 100); cnt++) {
                if (SkillProgressionList[cnt] != null) {
                    useableSkills.Add(SkillProgressionList[cnt]);
                }
            }
            return useableSkills;
        }

        /// <summary>
        /// Return all skills that become available between the old and new player level.
        /// </summary>
        /// <param name="oldPlayerLevel">Old player level</param>
        /// <param name="newPlayerLevel">New player level</param>
        /// <returns></returns>
        public List<Skill> GetNewSkills(int oldPlayerLevel, int newPlayerLevel)
        {
            List<Skill> newSkillList = new List<Skill>();
            for (int cnt = oldPlayerLevel - 1; cnt < Math.Min(newPlayerLevel, 100); cnt++) {
                if (SkillProgressionList[cnt] != null) {
                    newSkillList.Add(SkillProgressionList[cnt]);
                }
            }
            return newSkillList;
        }
    }
}