using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    public class Vector : Point
    {
        public Vector(int dim) : base(dim) { }

        public Vector(params float[] data) : base(data) { }

        public Vector(Matrix matrix) : base(matrix.Rows)
        {
            for (int i = 0; i < matrix.Rows; i++)
                this[i] = matrix[i, 0];
        }

        public float ScalarProduct(Vector vector)
        {
            Matrix identity = new Matrix(this.Rows);
            return identity.BilinearForm(this, vector);
        }

        public Vector VectorProduct(Vector vector)
        {
            if (vector.Rows != 3 || Rows != 3) throw new DimensionExeption();

            Vector result = new Vector(3);

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
            return (float)Math.Sqrt(this % this);
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            if (vector1.Rows != vector2.Rows ||
                vector1.Cols != vector2.Cols) throw new DimensionExeption();

            Vector result = new Vector(vector1.Rows);

            for (int i = 0; i < vector1.Rows; i++)
            {
                result[i] = vector1[i] + vector2[i];
            }

            return result;
        }

        public static Vector operator -(Vector vector1, Vector vector2)
            => vector1 + (-1 * vector2);

        public static Vector operator *(Vector vector, float scalar)
        {
            Vector result = new Vector(vector.Rows);
            
            for (int i = 0; i < vector.Rows; i++)
                result[i] = scalar * vector[i];

            return result;
        }

        public static Vector operator *(float scalar, Vector vector)
            => vector * scalar;

        public static Vector operator /(Vector vector, float scalar)
        {
            if (scalar == 0) throw new DivideByZeroException();

            return vector * (1 / scalar);
        }

        public static float operator %(Vector vector1, Vector vector2)
            => vector1.ScalarProduct(vector2);

        public static Vector operator ^(Vector vector1, Vector vector2)
            => vector1.VectorProduct(vector2);
    }
}
