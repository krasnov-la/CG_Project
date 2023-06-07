using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject.Engine
{
    public class EntityList : IEnumerable<Entity>
    {
        readonly Hashtable _hash = new();
        public EntityList() { }

        public Entity? this[Identifier key]
        {
            get { return (Entity?)_hash[key.ID]; }
        }

        public void Add(Entity obj)
        {
            _hash.Add(obj.Identifier.ID, obj);
        }

        public void Remove(Identifier key)
        {
            _hash.Remove(key.ID);
        }

        public void Remove(Entity obj)
        {
            _hash.Remove(obj.Identifier.ID);
        }

        public bool Contains(Identifier key)
        {
            return _hash.Contains(key.ID);
        }

        public Entity? Get(Identifier key)
        {
            if (!_hash.ContainsKey(key.ID))
                throw new KeyNotFoundException(key.ID);

            return (Entity?)_hash[key.ID];
        }

        public void Exec(Action<Entity> executable)
        {
            foreach (Entity obj in _hash.Values)
                executable(obj);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Entity> GetEnumerator()
        {
            foreach (Entity obj in _hash.Values)
                yield return obj;
        }
    }
}