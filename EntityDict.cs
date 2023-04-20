using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject
{
    namespace Engine
    {
        public class EntityDict
        {
            Dictionary<string, Entity> _dict = new Dictionary<string, Entity>();

            public EntityDict() {}

            public Entity this[string key]
            {
                get { return _dict[key]; }
            }

            public void Add(string key, Entity entity)
            {
                _dict.Add(key, entity);
            }

            public void Remove(string key)
            {
                _dict.Remove(key);
            }

            public Entity Get(string key)
            {
                if (_dict.ContainsKey(key))
                    return null;

                return _dict[key];
            }

            public void Exec(Action<Entity> executable)
            {
                foreach (Entity entity in _dict.Values)
                    executable(entity);
            }
        }
    }
}
