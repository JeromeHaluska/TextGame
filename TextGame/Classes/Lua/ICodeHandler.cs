namespace Game.Lua
{
    using System.Collections.Generic;

    public interface ICodeHandler
    {
        /// <summary>
        /// Creates a global variable inside the script and assigns a value to it.
        /// </summary>
        void SetVariable(string name, object value);

        /// <summary>
        /// Creates global variables inside the script and assigns values to them.
        /// </summary>
        void SetVariable(KeyValuePair<string, object>[] variableValuePairs);

        /// <summary>
        /// Calls a function from the code.
        /// </summary>
        /// <param name="functionName">The name of the function</param>
        /// <param name="arguments">Arguments that are getting passed to the function</param>
        /// <returns>The value returned by the function</returns>
        dynamic Call(string functionName, params object[] arguments);
    }
}
