namespace Game.Combat.Paths
{
    using System.IO;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Skills;
    using System;

    public class PathJsonReader
    {
        /// <summary>
        /// Initialises a json reader to read the path json file.
        /// </summary>
        /// <param name="path">The path that should be loaded.</param>
        public PathJsonReader(Path path)
        {
            // Gets the name of the path class.
            var pathClassName = path.GetType().Name.ToString();

            // Opens the path data file.
            TextReader fileReader = File.OpenText(Game.GetApplicationPath() + @"\data\paths\" + pathClassName + ".txt");

            // Initialises a json reader to read from the path data file.
            var jsonReader = new JsonTextReader(fileReader);

            // Get the name progression list.
            NameProgressionList = ReadNameProgressionList(jsonReader);

            // Get the starting skill list.
            StartingSkillList = ReadStartingSkillList(jsonReader);

            // Get the skill progression list.
            SkillProgressionList = ReadSkillProgressionList(jsonReader);
        }

        public string[] NameProgressionList { get; private set; } = new string[100];

        public List<Skill> StartingSkillList { get; private set; } = new List<Skill>();

        public Skill[] SkillProgressionList { get; private set; } = new Skill[100];

        /// <summary>
        /// Parses the name progression list from the path json file.
        /// </summary>
        private string[] ReadNameProgressionList(JsonReader jsonReader)
        {
            var insideList = false;
            var nameProgressionList = new string[100];

            // Parse the path data file.
            string curToken = null;
            string curValue = null;

            while (jsonReader.Read()) {
                var lastToken = curToken;
                var lastValue = curValue;

                curToken = jsonReader.TokenType.ToString();
                curValue = jsonReader.Value != null ? jsonReader.Value.ToString() : null;

                if (insideList) {
                    // When the list is loaded the method stops.
                    if (curToken == "EndObject") {
                        break;
                    }

                    if (lastToken == "PropertyName") {
                        int index;

                        // If the value of the last token was an integer it places the value of the current property into the 
                        if (int.TryParse(lastValue, out index)) {
                            nameProgressionList[index] = curValue;
                        }
                    }
                } else if (curValue == "NameProgressionList") {
                    insideList = true;
                }
            }

            return nameProgressionList;
        }

        /// <summary>
        /// Parses the starting skill list from the path json file.
        /// </summary>
        private List<Skill> ReadStartingSkillList(JsonReader jsonReader)
        {
            var insideList = false;
            var startingSkillList = new List<Skill>();

            // Parse the path data file.
            string curToken = null;
            string curValue = null;

            while (jsonReader.Read()) {
                curToken = jsonReader.TokenType.ToString();
                curValue = jsonReader.Value != null ? jsonReader.Value.ToString() : null;

                if (insideList) {
                    // When the list is loaded the method stops.
                    if (curToken == "EndArray") {
                        break;
                    }
                    
                    if (curValue != null) {
                        var skillType = Type.GetType("Game.Combat.Skills." + curValue);
                        startingSkillList.Add((Skill)Activator.CreateInstance(skillType));
                    }
                } else if (curValue == "StartingSkillList") {
                    insideList = true;
                }
            }

            return startingSkillList;
        }

        /// <summary>
        /// Parses the skill progression list from the path json file.
        /// </summary>
        private Skill[] ReadSkillProgressionList(JsonReader jsonReader)
        {
            var insideList = false;
            var skillProgressionList = new Skill[100];

            // Parse the path data file.
            string curToken = null;
            string curValue = null;

            while (jsonReader.Read()) {
                var lastToken = curToken;
                var lastValue = curValue;

                curToken = jsonReader.TokenType.ToString();
                curValue = jsonReader.Value != null ? jsonReader.Value.ToString() : null;

                if (insideList) {
                    // When the list is loaded the method stops.
                    if (curToken == "EndObject") {
                        break;
                    }

                    if (lastToken == "PropertyName") {
                        int index;

                        // If the value of the last token was an integer it places the value of the current property into the 
                        if (int.TryParse(lastValue, out index)) {
                            var skillType = Type.GetType("Game.Combat.Skills." + curValue);
                            var skillInstance = (Skill)Activator.CreateInstance(skillType);

                            skillProgressionList[index] = skillInstance;
                        }
                    }
                } else if (curValue == "SkillProgressionList") {
                    insideList = true;
                }
            }

            return skillProgressionList;
        }
    }
}
