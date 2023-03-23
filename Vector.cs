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
                SetElem(i, matrix.GetElem(i, 0));
        }

        public float ScalarProduct(Vector vector)
        {
            Matrix identity = new Matrix(this.Rows);
            return identity.BilinearForm(this, vector);
        }

        public Vector VectorProduct(Vector vector)
        {
            if (vector.Rows != 3 || Rows != 3) return null;

            Vector result = new Vector(3);

            result.SetElem(0, this.GetElem(1) * vector.GetElem(2) -
                              this.GetElem(2) * vector.GetElem(1));

            result.SetElem(1, this.GetElem(2) * vector.GetElem(0) -
                              this.GetElem(0) * vector.GetElem(2));

            result.SetElem(2, this.GetElem(0) * vector.GetElem(1) -
                              this.GetElem(1) * vector.GetElem(0));

            return result;
        }

        public float Lenght()
        {
            return (float)Math.Sqrt(this % this);
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            if (vector1.Rows != vector2.Rows) return null;

            Vector result = new Vector(vector1.Rows);

            for (int i = 0; i < vector1.Rows; i++)
            {
                result.SetElem(i, vector1.GetElem(i) + vector2.GetElem(i));
            }

            return result;
        }

        public static Vector operator -(Vector vector1, Vector vector2)
            => vector1 + (-1 * vector2);

        public static Vector operator *(Vector vector, float scalar)
        {
            Vector result = new Vector(vector.Rows);
            
            for (int i = 0; i < vector.Rows; i++)
                result.SetElem(i, scalar * vector.GetElem(i));

            return result;
        }

        public static Vector operator *(float scalar, Vector vector)
            => vector * scalar;

        public static Vector operator /(Vector vector, float scalar)
        {
            if (scalar == 0) return null;

            return vector * (1 / scalar);
        }

        public static float operator %(Vector vector1, Vector vector2)
            => vector1.ScalarProduct(vector2);

        public static Vector operator ^(Vector vector1, Vector vector2)
            => vector1.VectorProduct(vector2);
    }
}
