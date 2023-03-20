using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    class Matrix : DataTable
    {
        public Matrix(int rows, int cols) : base(rows, cols) { }

        public Matrix(float[,] data) : base(data.GetLength(0), data.GetLength(1))
        {
            for (int i = 0;i < Rows;i++)
                for (int j = 0;j < Cols;j++)
                    SetElem(i, j, data[i,j]);
        }

        public Matrix(int n) : base(n, n)
        {
            for (int i = 0; i < n; i++)
                SetElem(i, i, 1);
        }

        public float Determinant()
        {
            if (Rows != Cols) return float.NaN;

            if (Rows == 1) return GetElem(0, 0);

            int nonZero = -1;

            for (int i = 0; i < Rows;i++)
            {
                if (GetElem(i, 0) != 0)
                {
                    nonZero = i;
                    break;
                }
            }

            if (nonZero == -1) return 0;

            Matrix simple = new Matrix(Rows - 1, Cols - 1);

            for (int i = 0;i < nonZero; i++)
                for (int j = 0; j < Cols - 1;j++)
                    simple.SetElem(i, j, GetElem(i, j + 1));

            for (int i = nonZero + 1; i < Rows; i++)
            {
                float simplyficationScalar = GetElem(i, 0) / GetElem(nonZero, 0);

                for (int j = 0; j < Cols - 1; j++)
                {
                    float simpleEl = GetElem(i, j + 1)
                       - GetElem(nonZero, j + 1) * simplyficationScalar;

                    simple.SetElem(i - 1, j, simpleEl);
                }
            }

            return GetElem(nonZero, 0) * (nonZero % 2 == 0 ? 1 : -1) * simple.Determinant();
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows ||
                matrix1.Cols != matrix2.Cols) return null;

            Matrix result = new Matrix(matrix1.Rows, matrix1.Cols);

            for (int i = 0; i < matrix1.Rows; i++)
                for (int j = 0; j < matrix2.Rows; j++)
                    result.SetElem(i, j, 
                        matrix1.GetElem(i, j) + matrix2.GetElem(i, j));
            
            return result;
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
            => matrix1 + (-1 * matrix2);

        public static Matrix operator *(Matrix matrix, float scalar)
        {
            Matrix result = new Matrix(matrix.Rows, matrix.Cols);
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Cols; j++)
                    result.SetElem(i, j, scalar * matrix.GetElem(i, j));

            return result;
        }

        public static Matrix operator *(float scalar, Matrix matrix)
            => matrix * scalar;
    }
}
