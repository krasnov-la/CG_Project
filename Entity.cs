using CGProject.Math;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject
{
    namespace Engine
    {
        public enum EntityProps { Position, Direction, LookAt, FoV, DrawDist}

        public class Entity
        {
            static Type[] _propTypes = 
                {typeof(Point), typeof(Vector), typeof(Point), typeof(float), typeof(float) }; 

            Identifier _id = new Identifier();
            CoordinateSystem _coordSystem;
            Dictionary<EntityProps, object> _props = new Dictionary<EntityProps, object>();

            public Entity(CoordinateSystem coordinateSystem)
            {
                _coordSystem = coordinateSystem;
            }

            public object this[EntityProps prop]
            {
                get { return _props[prop]; }
                set 
                {
                    if (_propTypes[(int)prop] != value.GetType()) throw new EngineExceptions.PropertyTypeException();

                    else _props[prop] = value;
                }
            }

            public Identifier Identifier
            {
                get { return _id; }
            }

            public CoordinateSystem CoordinateSystem
            {
                get { return _coordSystem; }
            }

            public void RemoveProp(EntityProps prop)
            {
                if (!_props.ContainsKey(prop)) throw new EngineExceptions.NonExistantPropertyException();
                _props.Remove(prop);
            }

            public object GetProp(EntityProps prop)
                => _props[prop];

            public void SetProp(EntityProps prop, object val)
            {
                this[prop] = val;
            }

            public Dictionary<EntityProps, object>.KeyCollection ExistingProps()
                => _props.Keys;
        }
    }
}