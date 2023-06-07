using CGProject.Engine;
using CGProject.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject.Engine
{
    public class HyperPlane : GameObject //done
    {
        Vector _normal;

        public Vector Normal { get { return _normal; } }
        public HyperPlane(Game game, Point position, Vector normal) : base(game, position)
        {
            _normal = normal;
        }

        public override void RotatePlanar(int axis1, int axis2, float angle)
        {
            _normal = (Vector)(Matrix.GeneralRotation(CoordinateSystem.VS.Basis.Length, axis1, axis2, angle) * _normal);
        }

        public override void Rotate3D(float angleX, float angleY, float angleZ)
        {
            _normal = (Vector)(Matrix.Rotation(angleX, angleY, angleZ) * _normal);
        }

        public override float? IntersectionDist(Ray ray)
        {
            VectorSpace VS = CoordinateSystem.VS;
            Vector RayPosToPlanePos = VS.AsBaseVector(Position) - VS.AsBaseVector(ray.InitPt);
            float RayDirOnNormalScalarP = VS.ScalarProduct(ray.Dir, Normal);
            float NormalOnPositionsScalarP = VS.ScalarProduct(Normal, RayPosToPlanePos);

            float dist;
            if (System.Math.Abs(RayDirOnNormalScalarP) < 0.001)
                if (System.Math.Abs(NormalOnPositionsScalarP) < 0.001) return 0;
                else return null;
            else dist = NormalOnPositionsScalarP / RayDirOnNormalScalarP;

            return dist >= 0 ? dist : null;
        }
    }
}
