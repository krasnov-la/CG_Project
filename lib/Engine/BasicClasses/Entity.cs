using CGProject.Math;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CGProject.Engine
{
    public abstract class Entity
    {
        CoordinateSystem _cs;
        Point _pos;

        readonly Identifier _id = new();

        public Entity(CoordinateSystem cs, Point pos)
        {
            _pos = pos;
            _cs = cs;
        }

        public Identifier Identifier
        {
            get { return _id; }
        }

        public CoordinateSystem CoordinateSystem
        {
            get { return _cs; }
        }

        public Point Position { get => _pos; }

        public void Move(Vector direction)
        {
            _pos += direction;
        }

        public void SetPos(Point point)
        {
            _pos = point;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity) return false;
            return ((Entity)obj).Identifier.Equals(Identifier);
        }
    }
}