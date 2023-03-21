using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    class Point : DataTable
    {
        public Point(int dim) : base(dim, 1) { }
        
        public Point(float[] data) : base(data.Length, 1)
        {
            for (int i = 0;  i < data.Length; i++)
                SetElem(i, 0, data[i]);
        }

        public static Point operator +(Point point, Vector vector)
        {
            Point result = new Point(point.Rows);

            for (int i = 0;i < point.Rows;i++)
                result.SetElem(i, 0, point.GetElem(i, 0) + vector.GetElem(i, 0));
            
            return result;
        }

        public static Point operator -(Point point, Vector vector)
        {
            Point result = new Point(point.Rows);

            for (int i = 0; i < point.Rows; i++)
                result.SetElem(i, 0, point.GetElem(i, 0) - vector.GetElem(i, 0));

            return result;
        }
    }
}
