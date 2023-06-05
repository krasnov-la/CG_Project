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
        readonly CoordinateSystem _cs;
        readonly ObjectList _obj;

        public CoordinateSystem CoordinateSystem { get { return _cs; } }

        public ObjectList Objects { get => _obj; }

        public Game(CoordinateSystem cs, ObjectList entities)
        {
            _cs = cs;
            _obj = entities;
        }

        public void Run() { }

        public void Update() { }

        public void Exit() { }
    }
}