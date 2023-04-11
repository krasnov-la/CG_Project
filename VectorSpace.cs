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
            if (basis.Length == 0) throw new EmptyBasisException();
            if (basis[0].IsTransposed()) basis[0].Transpose();
            int dim = basis[0].Rows;
            for (int i = 0; i < basis.Length; i++)
            {
                if (basis[i].IsTransposed()) basis[i].Transpose();
                if (basis[i].Rows != dim) throw new DimensionException();
            }

            _basis = basis;
        }

        public float ScalarProduct(Vector vector1, Vector vector2)
        {
            if (vector1.IsTransposed() ||
                vector1.Rows != vector2.Rows) throw new DimensionException();
            vector1.Transpose();
            return (vector1 * Matrix.Gram(_basis) * vector2)[0, 0];
        }

        public float Length(Vector vector)
        {
            return (float)Math.Sqrt(this.ScalarProduct(vector, vector));
        }

        public Vector AsVector(Point point)
        {
            if (point.IsTransposed()) point.Transpose();

            if (point.Rows != _basis[0].Rows) throw new DimensionException(); 

            Vector result = new Vector(_basis[0].Rows);

            for (int i = 0; i < _basis.Length; i++)
                result += _basis[i] * point[i];

            return result;
        }
    }
}
