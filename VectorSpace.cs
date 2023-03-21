using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    public static class VectorSpace
    {
        public static Vector[] _basis = {new Vector(new float[] { 1, 0, 0 }),
                                         new Vector(new float[] { 0, 1, 0 }),
                                         new Vector(new float[] { 0, 0, 1 })};

        public static float ScalarProduct(Vector vector1, Vector vector2)
        {
            vector1.Transpose();
            return (vector1 * Matrix.Gram(_basis) * vector2).GetElem(0, 0);
        }

        public static Vector AsVector(Point point)
        {
            if (point.IsTransposed()) point.Transpose();

            if (point.Rows != _basis[0].Rows) return null; 

            Vector result = new Vector(_basis[0].Rows);

            for (int i = 0; i < _basis.Length; i++)
            {
                result += _basis[i] * point.GetElem(i);
            }

            return result;
        }
    }
}
