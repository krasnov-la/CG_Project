using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    public class Matrix : DataTable
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

        public Matrix(Vector vector) : base(vector.Rows, vector.Cols)
        {
            for (int i = 0; i < vector.Rows; i++)
                for (int j = 0; j < vector.Cols; j++)
                    SetElem(i, j, vector.GetElem(i, j));
        }

        public float BilinearForm(Vector vector1, Vector vector2)
        {
            if (vector1.Rows != Rows || vector2.Rows != Cols) return float.NaN;

            float result = 0;

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    result += GetElem(i, j) * vector1.GetElem(i) * vector2.GetElem(j);

            return result;
        }

        public static Matrix Gram(Vector[] vectors)
        {
            int normal = vectors[0].Rows;
            for (int i = 1;i < vectors.Length; i++)
                if (vectors[i].Rows != normal) return null;

            Matrix result = new Matrix(vectors.Length, vectors.Length);

            for (int i = 0; i < result.Rows; i++)
                for (int j = 0; j < result.Cols; j++)
                    result.SetElem(i, j, vectors[i] % vectors[j]);

            return result;
        }

        float GetCofactor(int row, int col)
        {
            Matrix minor = new Matrix(Rows - 1, Cols - 1);

            for (int k = 0; k < row; k++)
                for (int l = 0; l < col; l++)
                    minor.SetElem(k, l, GetElem(k, l));

            for (int k = row + 1; k < Rows; k++)
                for (int l = col + 1; l < Cols; l++)
                    minor.SetElem(k - 1, l - 1, GetElem(k, l));

            for (int k = row + 1; k < Rows; k++)
                for (int l = 0; l < col; l++)
                    minor.SetElem(k - 1, l, GetElem(k, l));

            for (int k = 0; k < row; k++)
                for (int l = col + 1; l < Cols; l++)
                    minor.SetElem(k, l - 1, GetElem(k, l));

            return minor.Determinant() * ((row + col) % 2 == 0 ? 1 : -1);
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

        public Matrix Inverse()
        {
            if (Rows != Cols) return null;

            Matrix result = new Matrix(Rows, Cols);

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                {
                    result.SetElem(i, j, GetCofactor(i, j));
                }

            result.Transpose();
            result /= Determinant();
            return result;
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

        public static Matrix operator /(Matrix matrix, float scalar)
        {
            if (scalar == 0) return null;
            return matrix * (1 / scalar);
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Cols != matrix2.Rows) return null;

            Matrix result = new Matrix(matrix1.Rows, matrix2.Cols);

            for (int i = 0; i <  result.Rows; i++)
                for (int j = 0; j < result.Cols; j++)
                {
                    float elem = 0;

                    for (int k = 0; k < matrix1.Cols; k++)
                    {
                        elem += matrix1.GetElem(i, k) * matrix2.GetElem(k, j);
                    }

                    result.SetElem(i, j, elem);
                }

            return result;
        }

        public static Matrix operator /(Matrix matrix1, Matrix matrix2)
            => matrix1 * matrix2.Inverse();

        public static Matrix operator *(Matrix matrix, Vector vector)
        {
            Matrix vectorMatrix = new Matrix(vector);
            return matrix * vectorMatrix;
        }

        public static Matrix operator *(Vector vector, Matrix matrix)
        {
            Matrix vectorMatrix = new Matrix(vector);
            return vectorMatrix * matrix;
        }
    }
}
