using CGProject.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject.Engine
{
    public class Game
    {
        CoordinateSystem _cs;
        EntityList _entities;

        public CoordinateSystem CoordinateSystem { get { return _cs; } }

        public Entity this[Identifier id]
        {
            get { return _entities[id]; }
        }

        public Game(CoordinateSystem cs, EntityList entities)
        {
            _cs = cs;
            _entities = entities;
        }

        public void Push(Entity entity)
        {
            _entities.Add(entity);
        }

        public void Remove(Identifier id)
        {
            _entities.Remove(id);
        }

        public void Run() { }

        public void Update() { }

        public void Exit() { }
    }
}