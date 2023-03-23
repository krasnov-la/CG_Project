using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    public class CoordinateSystem
    {
        public Point _initPoint;
        public VectorSpace _vs;

        public CoordinateSystem(Point initPoint, VectorSpace vs)
        {
            _initPoint = initPoint;
            _vs = vs;
        }
    }
}
