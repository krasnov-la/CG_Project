using CGProject.Math;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CGProject.Engine
{
    public enum EntityProp { Position, Direction, LookAt, FoV, DrawDist, Normal } // Инициализация свойств через конфиг?? 

    public class Entity
    {
        static Type[] _propTypes =
            {typeof(Point), typeof(Vector), typeof(Point), typeof(float), typeof(float), typeof(Vector) };

        Identifier _id = new();
        CoordinateSystem _coordSystem;
        Dictionary<EntityProp, object> _props = new();

        public Entity(CoordinateSystem coordinateSystem)
        {
            _coordSystem = coordinateSystem;
        }

        public dynamic this[EntityProp prop]
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

        public void RemoveProp(EntityProp prop)
        {
            if (!_props.ContainsKey(prop)) throw new EngineExceptions.NonExistantPropertyException();
            _props.Remove(prop);
        }

        public object GetProp(EntityProp prop)
            => this[prop];

        public void SetProp(EntityProp prop, object val)
        {
            this[prop] = val;
        }

        public Dictionary<EntityProp, object>.KeyCollection ExistingProps()
            => _props.Keys;

        public bool Contains(EntityProp prop)
            => _props.ContainsKey(prop);

        public override bool Equals(object? obj)
        {
            if (!(obj is Entity)) return false;
            return ((Entity)obj).Identifier.Equals(Identifier);
        }
    }
}