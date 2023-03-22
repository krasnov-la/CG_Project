using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    public class VectorSpace
    {
        public Vector[] _basis;

        public VectorSpace(params Vector[] basis)
        {
            _basis = basis;
        }

        public float ScalarProduct(Vector vector1, Vector vector2)
        {
            vector1.Transpose();
            return (vector1 * Matrix.Gram(_basis) * vector2).GetElem(0, 0);
        }

        public Vector AsVector(Point point)
        {
            if (point.IsTransposed()) point.Transpose();

            if (point.Rows != _basis[0].Rows) return null; 

            Vector result = new Vector(_basis[0].Rows);

            for (int i = 0; i < _basis.Length; i++)
                result += _basis[i] * point.GetElem(i);

            return result;
        }
    }
}
