using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGProject.Math;

namespace CGProject.Engine
{
    public abstract class GameObject : Entity
    {
        public event EventHandler<Vector> Rotated;
        public GameObject(Game game, Point position) : base(game.CoordinateSystem, position)
        {
            game.Objects.Add(this);    
        }

        public abstract void RotatePlanar(int axis1, int axis2, float angle);

        public abstract void Rotate3D(float angleX, float angleY, float angleZ);

        public abstract float? IntersectionDist(Ray ray);
    }
}