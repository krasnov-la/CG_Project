using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CG_Project
{
    public class Point : DataTable
    {
        public Point(int dim) : base(dim, 1) { }
        
        public Point(float[] data) : base(data.Length, 1)
        {
            for (int i = 0;  i < data.Length; i++)
                SetElem(i, data[i]);
        }

        public void SetElem(int row, float value)
        {
            base.SetElem(row, 0, value);
        }

        public float GetElem(int row)
        {
            return base.GetElem(row, 0);
        }

        public static Point operator +(Point point, Vector vector)
        {
            Point result = new Point(point.Rows);

            for (int i = 0;i < point.Rows;i++)
                result.SetElem(i, point.GetElem(i) + vector.GetElem(i));
            
            return result;
        }

        public static Point operator -(Point point, Vector vector)
            => point + (-1 * vector);
    }
}
