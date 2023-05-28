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
        public class GameObject : Entity
        {
            Game _game;
            public GameObject(Game game, Point position, Vector direction) : base (game.CoordinateSystem)
            {
                SetProp(EntityProps.Position, position);
                SetProp(EntityProps.Direction, direction);
                _game = game;
                game.Push(this);
            }

            public void Move(Vector direction)
            {
                this[EntityProps.Position] = (Point)this[EntityProps.Position] + direction;
            }

            public void RotatePlanar(int axis1, int axis2, float angle)
            {
                this[EntityProps.Direction] = (Vector)(Matrix.GeneralRotation(CoordinateSystem.VS.Basis.Length, axis1, axis2, angle) * (Vector)this[EntityProps.Direction]);
            }

            public void Rotate3D(int angleX, int angleY, int angleZ)
            {
                this[EntityProps.Direction] = (Vector)(Matrix.Rotation(angleX, angleY, angleZ) * (Vector)this[EntityProps.Direction]);
            }

            public void SetPos(Point point)
            {
                this[EntityProps.Position] = point;
            }

            public void SetDir(Vector vector)
            {
                this[EntityProps.Direction] = vector;
            }
        }
    }
}
