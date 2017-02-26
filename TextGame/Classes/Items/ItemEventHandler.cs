namespace Game.Items
{
    using System.Collections.Generic;
    using Lua;

    public enum ItemEvent
    {
        OnUse
    }

    public class ItemEventHandler
    {
        private static Dictionary<ItemEvent, string> _eventToString = new Dictionary<ItemEvent, string> {
            { ItemEvent.OnUse, "OnUse" }
        };

        private ICodeHandler _codeHandler;

        public ItemEventHandler(string filePath)
        {
            _codeHandler = new LuaHandler(filePath);
        }

        public ItemEventResult Call(ItemEvent itemEvent, params object[] arguments)
        {
            var result = _codeHandler.Call(_eventToString[itemEvent], arguments);

            return new ItemEventResult();
        }
    }

    public struct ItemEventResult
    {

    }
}
