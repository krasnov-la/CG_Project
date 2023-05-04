using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject
{
    namespace Engine
    {
        public class EntityList
        {
            Hashtable _hash = new Hashtable();

            public EntityList() { }

            public Entity this[Identifier key]
            {
                get { return (Entity)_hash[key.ID]; }
            }

            public void Add(Entity entity)
            {
                _hash.Add(entity.Identifier.ID, entity);
            }

            public void Remove(Identifier key)
            {
                _hash.Remove(key.ID);
            }

            public void Remove(Entity entity)
            {
                _hash.Remove(entity.Identifier.ID);
            }

            public Entity Get(Identifier key)
            {
                if (!_hash.ContainsKey(key.ID))
                    throw new EngineExceptions.NonExistantPropertyException();

                return (Entity)_hash[key.ID];
            }

            public void Exec(Action<Entity> executable)
            {
                foreach (Entity entity in _hash.Values)
                    executable(entity);
            }
        }
    }
}
