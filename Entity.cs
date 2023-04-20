using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGProject.Math;

namespace CGProject
{
    namespace Engine
    {
        public class Entity
        {
            public enum EntityProps {};

            Identifier _id;
            CoordinateSystem _coordSystem;
            Dictionary<EntityProps, int> _props;

            public int this[EntityProps prop]
            {
                get { return _props[prop]; }
                set { _props[prop] = value;}
            }

            public string ID
            {
                get { return _id.ID; }
            }

            public CoordinateSystem CoordinateSystem
            {
                get { return _coordSystem; }
            }

            public Entity(CoordinateSystem coordinateSystem)
            {
                _id = new Identifier(this);
                _coordSystem = coordinateSystem;
            }

            public void PropRemove(EntityProps prop)
            {
                _props.Remove(prop);
            }

            public void PropAdd(EntityProps prop, int val)
            {
                _props.Add(prop, val);
            }

            public int GetProp(EntityProps prop)
                => _props[prop];

            public void SetProp(EntityProps prop, int val)
            {
                _props[prop] = val;
            }

            public Dictionary<EntityProps, int>.KeyCollection ExistingProps()
                => _props.Keys;
        }
    }
}