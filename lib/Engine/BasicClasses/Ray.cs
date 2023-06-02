using CGProject.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject.Engine
{
    public class Ray
    {
        CoordinateSystem _coordinateSystem;
        Point _initPt;
        Vector _dir;

        public Vector Dir { get { return _dir; } }

        public Point InitPt { get { return _initPt; } }

        public void Rotate3D(float angleX, float angleY, float angleZ)
        {
            _dir = (Vector)(Matrix.Rotation(angleX, angleY, angleZ) * _dir);
        }

        public CoordinateSystem CoordinateSystem { get { return _coordinateSystem; } }

        public Ray(CoordinateSystem coordinateSystem, Point initPt, Vector dir)
        {
            _coordinateSystem = coordinateSystem;
            _initPt = initPt;
            _dir = dir;
        }

        public void Normalize()
        {
            _dir = _dir / _coordinateSystem.VS.Length(_dir);
        }
    }
}