using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject
{
    namespace Math
    {
        public class Vector : Point
        {
            public Vector(int dim) : base(dim) { }

            public Vector(int rows, int cols) : base(rows, cols) { }

            public Vector(params float[] data) : base(data) { }

            float ScalarProduct(Vector vector)
            {
                Matrix identity = new(this.Rows);
                return identity.BilinearForm(this, vector);
            }

            Vector VectorProduct(Vector vector)
            {
                if (vector.Rows != 3 || Rows != 3) throw new EngineExceptions.DimensionException();

                Vector result = new(3);

                result[0] = this[1] * vector[2] -
                            this[2] * vector[1];

                result[1] = this[2] * vector[0] -
                            this[0] * vector[2];

                result[2] = this[0] * vector[1] -
                            this[1] * vector[0];

                return result;
            }

            public float Lenght()
            {
                return (float)System.Math.Sqrt(this % this);
            }

            public static Vector ConvFromMatrix(Matrix matrix)
            {
                if (matrix.Cols != 1) throw new EngineExceptions.DimensionException();

                Vector res = new(matrix.Rows);

                for (int i = 0; i < matrix.Rows; i++)
                    res[i] = matrix[i, 0];

                return res;
            }

            public static Vector Sum(Vector vector1, Vector vector2)
            {
                if (vector1.Rows != vector2.Rows ||
                    vector1.Cols != vector2.Cols) throw new EngineExceptions.DimensionException();

                Vector result = new(vector1.Rows);

                for (int i = 0; i < vector1.Rows; i++)
                {
                    result[i] = vector1[i] + vector2[i];
                }

                return result;
            }

            public static Vector ScalarMult(Vector vector, float scalar)
            {
                Vector result = new(vector.Rows);

                for (int i = 0; i < vector.Rows; i++)
                    result[i] = scalar * vector[i];

                return result;
            }



            public static explicit operator Vector(Matrix matrix)
                => ConvFromMatrix(matrix);

            public static Vector operator +(Vector vector1, Vector vector2)
                => Sum(vector1, vector2);

            public static Vector operator -(Vector vector1, Vector vector2)
                => vector1 + (-1 * vector2);

            public static Vector operator *(Vector vector, float scalar)
                => ScalarMult(vector, scalar);

            public static Vector operator *(float scalar, Vector vector)
                => vector * scalar;

            public static Vector operator /(Vector vector, float scalar)
                => vector * (1 / scalar);

            public static float operator %(Vector vector1, Vector vector2)
                => vector1.ScalarProduct(vector2);

            public static Vector operator ^(Vector vector1, Vector vector2)
                => vector1.VectorProduct(vector2);
        }
    }
}
