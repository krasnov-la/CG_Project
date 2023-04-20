using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject
{
    namespace Math
    {
        public class CoordinateSystem
        {
            Point _initPoint;
            VectorSpace _vs;

            public CoordinateSystem(Point initPoint, VectorSpace vs)
            {
                _initPoint = initPoint;
                _vs = vs;
            }

            public Point InitPoint
            { get { return _initPoint; } }

            public VectorSpace VS
            { get { return _vs; } }
        }
    }
}
