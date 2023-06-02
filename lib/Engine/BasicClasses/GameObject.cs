using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGProject.Math;

namespace CGProject.Engine
{
    public class GameObject : Entity
    {
        Game _game;
        public GameObject(Game game, Point position, Vector direction) : base(game.CoordinateSystem)
        {
            SetProp(EntityProp.Position, position);
            SetProp(EntityProp.Direction, direction);
            _game = game;
            game.Push(this);
        }

        public void Move(Vector direction)
        {
            this[EntityProp.Position] = (Point)this[EntityProp.Position] + direction;
        }

        public void RotatePlanar(int axis1, int axis2, float angle)
        {
            this[EntityProp.Direction] = (Vector)(Matrix.GeneralRotation(CoordinateSystem.VS.Basis.Length, axis1, axis2, angle) * (Vector)this[EntityProp.Direction]);
        }

        public void Rotate3D(int angleX, int angleY, int angleZ)
        {
            this[EntityProp.Direction] = (Vector)(Matrix.Rotation(angleX, angleY, angleZ) * (Vector)this[EntityProp.Direction]);
        }

        public void SetPos(Point point)
        {
            this[EntityProp.Position] = point;
        }

        public void SetDir(Vector vector)
        {
            this[EntityProp.Direction] = vector;
        }

        public virtual float IntersectionDist(Ray ray)
        {
            return 0;
        }
    }
}