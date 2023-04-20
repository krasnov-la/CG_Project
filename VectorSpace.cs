using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject
{
    namespace Math
    {
        public class VectorSpace
        {
            public Vector[] _basis;

            public Vector[] Basis
            { get { return _basis; } }

            public VectorSpace(params Vector[] basis)
            {
                if (basis.Length == 0) throw new EngineExceptions.EmptyBasisException();
                if (basis[0].IsTransposed()) basis[0].Transpose();
                int dim = basis[0].Rows;
                for (int i = 0; i < basis.Length; i++)
                {
                    if (basis[i].IsTransposed()) basis[i].Transpose();
                    if (basis[i].Rows != dim) throw new EngineExceptions.DimensionException();
                }

                _basis = basis;
            }

            public Vector VectorProduct(Vector vector1, Vector vector2)
            {
                if (vector1.Rows != 3 || vector2.Rows != 3) throw new EngineExceptions.DimensionException();

                Vector result = new Vector(3);

                result += Basis[0] * (vector1[1] * vector2[2] -
                                      vector1[2] * vector2[1]);

                result += Basis[1] * (vector1[2] * vector2[0] -
                                      vector1[0] * vector2[2]);

                result += Basis[2] * (vector1[0] * vector2[1] -
                                      vector1[1] * vector2[0]);

                return result;
            }

            public float ScalarProduct(Vector vector1, Vector vector2)
            {
                if (vector1.IsTransposed() ||
                    vector1.Rows != vector2.Rows) throw new EngineExceptions.DimensionException();
                vector1.Transpose();
                return (vector1 * Matrix.Gram(_basis) * vector2)[0, 0];
            }

            public float Length(Vector vector)
            {
                return (float)System.Math.Sqrt(this.ScalarProduct(vector, vector));
            }

            public Vector AsVector(Point point)
            {
                if (point.IsTransposed()) point.Transpose();

                if (point.Rows != _basis[0].Rows) throw new EngineExceptions.DimensionException();

                Vector result = new Vector(_basis[0].Rows);

                for (int i = 0; i < _basis.Length; i++)
                    result += _basis[i] * point[i];

                return result;
            }
        }
    }
}
