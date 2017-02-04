namespace Game.Lua
{
    using System.Collections.Generic;
    using NLua;

    class LuaHandler
    {
        private Lua _state = new Lua();

        private Dictionary<string, LuaFunction> _storedFunctions = new Dictionary<string, LuaFunction>();

        public LuaHandler(string filePath)
        {
            var fullFilePath = Game.GetApplicationPath() + @"\lua\" + filePath;

            // Enable import function inside lua scripts.
            _state.LoadCLRPackage();

            _state.DoFile(fullFilePath);
        }

        /// <summary>
        /// Creates a global variable inside the lua script and assigns a value to it.
        /// </summary>
        public void SetVariable(string name, object value)
        {
            _state[name] = value;
        }

        /// <summary>
        /// Creates global variables inside the lua script and assigns values to them.
        /// </summary>
        public void SetVariable(KeyValuePair<string, object>[] variableValuePairs)
        {
            foreach (KeyValuePair<string, object> variableValuePair in variableValuePairs) {
                SetVariable(variableValuePair.Key, variableValuePair.Value);
            }
        }

        public dynamic Call(string functionName, params object[] arguments)
        {
            LuaFunction function;

            // The function gets stored for later usage if it hasn't been called before.
            if (_storedFunctions.ContainsKey(functionName)) {
                function = _storedFunctions[functionName];
            } else {
                function = _state[functionName] as LuaFunction;
                _storedFunctions.Add(functionName, function);
            }

            return function.Call(arguments);
        }
    }
}
