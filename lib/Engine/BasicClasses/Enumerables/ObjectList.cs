using System.Collections;
using System.Collections.Generic;

namespace CGProject.Engine
{
    public class ObjectList : IEnumerable<GameObject>
    {
        readonly Hashtable _hash = new();
        public ObjectList() { }

        public GameObject? this[Identifier key]
        {
            get { return (GameObject?)_hash[key.ID]; }
        }

        public void Add(GameObject obj)
        {
            _hash.Add(obj.Identifier.ID, obj);
        }

        public void Remove(Identifier key)
        {
            _hash.Remove(key.ID);
        }

        public void Remove(GameObject obj)
        {
            _hash.Remove(obj.Identifier.ID);
        }

        public bool Contains(Identifier key)
        {
            return _hash.Contains(key.ID);
        }

        public GameObject? Get(Identifier key)
        {
            if (!_hash.ContainsKey(key.ID))
                throw new KeyNotFoundException(key.ID);

            return (GameObject?)_hash[key.ID];
        }

        public void Exec(Action<GameObject> executable)
        {
            foreach (GameObject obj in _hash.Values)
                executable(obj);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<GameObject> GetEnumerator()
        {
            foreach (GameObject obj in _hash.Values)
                yield return obj;
        }
    }
}