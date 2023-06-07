using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGProject.Math;

namespace CGProject.Engine
{
    public class EventSystem
    {
        readonly Dictionary<ConsoleKey, List<Tuple<Entity, Action<Entity>>>> _keyMapping = new();

        public EventSystem(MainLoop loop)
        {
            loop.KeyPress += KeyPress;
        }

        private void KeyPress(object? sender, ConsoleKeyInfo e)
        {
            if (_keyMapping.ContainsKey(e.Key))
                foreach (var actionPair in _keyMapping[e.Key])
                {
                    Action<Entity> act = actionPair.Item2;
                    if (act != null) act(actionPair.Item1);
                }
        }
    }
}
