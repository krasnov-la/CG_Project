namespace CGProject.Engine
{
    public class KeyMapper
    {
        readonly Dictionary<ConsoleKey, List<Tuple<Entity, Action<Entity>>>> _keyMapping = new();

        public KeyMapper(Game game)
        {
            game.KeyPress += KeyPress;
        }

        private void KeyPress(object? sender, ConsoleKeyInfo e)
        {
            if (_keyMapping.ContainsKey(e.Key))
                foreach (var actionPair in _keyMapping[e.Key])
                    actionPair.Item2?.Invoke(actionPair.Item1);
        }

        public void Add(ConsoleKey key, Entity ent, Action<Entity> act) 
        {
            Tuple<Entity, Action<Entity>> pair = new(ent, act);
            if (!_keyMapping.ContainsKey(key)) _keyMapping[key] = new List<Tuple<Entity, Action<Entity>>> { pair };
            else _keyMapping[key].Add(pair);
        }

        public void Clear(ConsoleKey key)
        {
            _keyMapping[key].Clear();
        }

        public void Remove(ConsoleKey key, Tuple<Entity, Action<Entity>> pair)
        {
            _keyMapping[key].Remove(pair);
        }
    }
}
