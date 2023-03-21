using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    class Vector : Point
    {
        public Vector(int dim) : base(dim) { }
        
        public Vector(float[] data) : base(data) { }

        float ScalarProduct(Vector vector)
        {
            if (Rows != vector.Rows) return float.NaN;

            float result = 0;

            for (int i = 0; i < Rows; i++)
                result += GetElem(i, 0) * vector.GetElem(i, 0);

            return result; 
        }

        Vector VectorProduct(Vector vector)
        {
            Vector res = new Vector(vector.Rows);
            return res;
        }

        float Lenght()
        {
            return (float)Math.Sqrt(ScalarProduct(this));
        }

        public static float operator %(Vector vector1, Vector vector2)
            => vector1.ScalarProduct(vector2);

        public static Vector operator ^(Vector vector1, Vector vector2)
            => vector1.VectorProduct(vector2);
    }
}
