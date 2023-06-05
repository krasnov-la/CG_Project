using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CGProject.Math
{
    public class Point : DataTable
    {
        public Point(int dim) : base(dim, 1) { }

        public Point(int rows, int cols) : base(rows, cols) { if (cols != 1) throw new EngineExceptions.DimensionException(); }

        public Point(params float[] data) : base(data.Length, 1)
        {
            for (int i = 0; i < data.Length; i++)
                this[i] = data[i];
        }

        public float this[int i]
        {
            get { return GetElem(i); }
            set { SetElem(i, value); }
        }

        void SetElem(int row, float value)
        {
            SetElem(row, 0, value);
        }

        float GetElem(int row)
        {
            return GetElem(row, 0);
        }

        public static Point PointVectorSum(Point point, Vector vector)
        {
            if (vector.Rows != point.Rows ||
                vector.Cols != point.Cols) throw new EngineExceptions.DimensionException();

            Point result = new(point.Rows);

            for (int i = 0; i < point.Rows; i++)
                result[i] = point[i] + vector[i];

            return result;
        }

        public static Point operator +(Point point, Vector vector)
            => PointVectorSum(point, vector);

        public static Point operator -(Point point, Vector vector)
            => PointVectorSum(point, -1 * vector);
    }
}