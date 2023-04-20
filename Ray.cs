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
        class Ray
        {
            CoordinateSystem _coordinateSystem;
            Point _initPt;
            Vector _dir;

            public Vector Dir { get { return _dir; } }

            public Point InitPt { get { return _initPt; } }

            public CoordinateSystem CoordinateSystem { get { return _coordinateSystem; } }

            public Ray(CoordinateSystem coordinateSystem, Point initPt, Vector dir)
            {
                _coordinateSystem = coordinateSystem;
                _initPt = initPt;
                _dir = dir;
            }
        }
    }
}
