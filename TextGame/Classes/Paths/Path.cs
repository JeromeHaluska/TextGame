namespace Game.Paths
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using Skills;

    public class Path
    {
        public Path(string pathName)
        {
            ParseJson(pathName);
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
            List<Skill> useableSkillList = new List<Skill>();
            if (StartingSkillList != null) {
                foreach (Skill skill in StartingSkillList) {
                    useableSkillList.Add(skill);
                }
            }
            for (int cnt = 0; cnt < Math.Min(playerLevel, 100); cnt++) {
                if (SkillProgressionList[cnt] != null) {
                    useableSkillList.Add(SkillProgressionList[cnt]);
                }
            }
            return useableSkillList;
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

        /// <summary>
        /// Parses the path data from the path file.
        /// </summary>
        /// <param name="pathName">The path name</param>
        private void ParseJson(string pathName)
        {
            // Opens the path data file.
            TextReader fileReader = File.OpenText(Game.GetApplicationPath() + @"\data\paths\" + pathName + ".txt");

            // Initialises a json reader to read from the path data file.
            var jsonReader = new JsonTextReader(fileReader);

            // Parse the json data.
            var serializer = new JsonSerializer();
            var jsonObject = serializer.Deserialize<Dictionary<string, Dictionary<int, string>>>(jsonReader);

            foreach (KeyValuePair<string, Dictionary<int, string>> propertyDictionaryPair in jsonObject) {
                var curObjectName = propertyDictionaryPair.Key;

                foreach (KeyValuePair<int, string> propertyValuePair in propertyDictionaryPair.Value) {
                    Type skillType;
                    Skill skillInstance;

                    switch (curObjectName) {
                        case "NameProgressionList":
                        NameProgressionList[propertyValuePair.Key] = propertyValuePair.Value;
                        break;
                        case "StartingSkillList":
                        skillType = Type.GetType("Game.Skills." + propertyValuePair.Value);
                        skillInstance = (Skill)Activator.CreateInstance(skillType);

                        StartingSkillList.Add(skillInstance);
                        break;
                        case "SkillProgressionList":
                        skillType = Type.GetType("Game.Skills." + propertyValuePair.Value);
                        skillInstance = (Skill)Activator.CreateInstance(skillType);

                        SkillProgressionList[propertyValuePair.Key] = skillInstance;
                        break;
                    }
                }
            }
        }
    }
}