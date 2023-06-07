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
        readonly CoordinateSystem _coordinateSystem;
        readonly Point _initPt;
        Vector _dir;

        public Vector Dir { get { return _dir; }
            set { _dir = value; }
        }

        public Point InitPt { get { return _initPt; } }

        public CoordinateSystem CoordinateSystem { get { return _coordinateSystem; } }

        public Ray SpaceSwap(VectorSpace vs)
        {
            Vector baseDir = CoordinateSystem.VS.AsBaseVector(_dir);
            Vector basePt = CoordinateSystem.VS.AsBaseVector(_initPt);
            Vector baseInitPt = CoordinateSystem.VS.AsBaseVector(CoordinateSystem.InitPoint);

            Vector newDir = vs.AsVectorInBasis(baseDir);
            Vector newPt = vs.AsVectorInBasis(basePt);
            Vector newInitPt = vs.AsVectorInBasis(baseInitPt);

            return new Ray(new CoordinateSystem(newInitPt, vs), newPt, newDir);
        }

        public Ray(CoordinateSystem coordinateSystem, Point initPt, Vector dir)
        {
            _coordinateSystem = coordinateSystem;
            _initPt = initPt;
            _dir = dir;
        }

        public void Normalize()
        {
            _dir = CoordinateSystem.VS.Normalize(_dir);
        }
    }
}