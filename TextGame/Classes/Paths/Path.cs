namespace Game.Paths
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using Skills;
    using Newtonsoft.Json.Linq;

    public class Path
    {
        static private Path[] _paths;

        static public Path[] GetAllPaths()
        {
            if (_paths == null) {
                var pathList = new List<Path>();

                // Open the path data file and extract the raw JSON.
                TextReader fileReader = File.OpenText(Game.GetApplicationPath() + @"\data\paths.txt");
                var rawJson = fileReader.ReadToEnd();

                // Convert the raw JSON into a dynamic array of path objects for easy access.
                var serializer = new JsonSerializer();
                dynamic pathDataArray = JArray.Parse(rawJson);

                // Fill the pathList with Path objects.
                foreach (dynamic pathData in pathDataArray) {
                    pathList.Add(new Path(pathData));
                }

                _paths = pathList.ToArray();
            }
            return _paths;
        }

        static public Path GetPath(string pathName, int playerLevel)
        {
            foreach (Path path in _paths) {
                if (path.GetName(playerLevel) == pathName) {
                    return path;
                }
            }
            return null;
        }

        /// <summary>
        /// The name of the path can change when the player level increases.
        /// </summary>
        private KeyValuePair<int, string>[] _nameProgressionList { get; set; }

        /// <summary>
        /// The skills that are available from the start of the game.
        /// </summary>
        private Skill[] _startingSkillList { get; set; }

        /// <summary>
        /// The skills that become available when the player level increases.
        /// All the skills which key is lower or equal than the player level are useable.
        /// </summary>
        private KeyValuePair<int, Skill>[] _skillProgressionList { get; set; }

        /// <summary>
        /// Creates a Path object with data from a JSON object
        /// </summary>
        /// <param name="pathData">A JSON object</param>
        public Path(dynamic pathData)
        {
            // Fill the description.
            var descriptionList = new List<string>();

            foreach(string line in pathData.description) {
                descriptionList.Add(line);
            }
            Description = descriptionList.ToArray();

            // Fill the name progression list.
            var nameProgressionList = new List<KeyValuePair<int, string>>();

            foreach (dynamic nameProgressionData in pathData.nameProgressionList) {
                nameProgressionList.Add(new KeyValuePair<int, string>((int)nameProgressionData.level.Value, nameProgressionData.name.Value));
            }
            _nameProgressionList = nameProgressionList.ToArray();

            // Fill the starting skill list.
            var startingSkillList = new List<Skill>();

            foreach (string skillName in pathData.startingSkillList) {
                startingSkillList.Add(Skill.GetSkillInstance(skillName));
            }
            _startingSkillList = startingSkillList.ToArray();

            // Fill the skill progression list.
            var skillProgressionList = new List<KeyValuePair<int, Skill>>();

            foreach (dynamic skillProgressionData in pathData.skillProgressionList) {
                var skillInstance = Skill.GetSkillInstance(skillProgressionData.name.Value);

                skillProgressionList.Add(new KeyValuePair<int, Skill>((int)skillProgressionData.level.Value, skillInstance));
            }
            _skillProgressionList = skillProgressionList.ToArray();
        }

        public string[] Description;

        public string GetName(int playerLevel)
        {
            foreach (KeyValuePair<int, string> levelNamePair in _nameProgressionList) {
                if (playerLevel >= levelNamePair.Key) {
                    return levelNamePair.Value;
                }
            }
            return "unknown";
        }

        /// <summary>
        /// Returns all skills that are currently available to the player.
        /// </summary>
        /// <param name="playerLevel">Current player level</param>
        /// <returns></returns>
        public Skill[] GetUsableSkills(int playerLevel)
        {
            List<Skill> useableSkillList = new List<Skill>();
            
            foreach (Skill skill in _startingSkillList) {
                useableSkillList.Add(skill);
            }

            // Add all skills form the skill progression list to the useable skill list whose level requirement is met.
            foreach (KeyValuePair<int, Skill> requirementSkillPair in _skillProgressionList) {
                if (playerLevel >= requirementSkillPair.Key) {
                    useableSkillList.Add(requirementSkillPair.Value);
                }
            }

            return useableSkillList.ToArray();
        }

        /// <summary>
        /// Return all skills that become available between the old and new player level.
        /// </summary>
        /// <returns>A skill array</returns>
        public Skill[] GetNewSkills(int oldPlayerLevel, int newPlayerLevel)
        {
            List<Skill> newSkillList = new List<Skill>();

            // Check the skill progression list for skills that level requirement wasn't met with the old level.
            foreach (KeyValuePair<int, Skill> requirementSkillPair in _skillProgressionList) {

                if (newPlayerLevel >= requirementSkillPair.Key && oldPlayerLevel < requirementSkillPair.Key) {
                    newSkillList.Add(requirementSkillPair.Value);
                }
            }

            return newSkillList.ToArray();
        }
    }
}