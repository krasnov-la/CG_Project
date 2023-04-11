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
                    this[i, j] = data[i, j];
        }

        public Matrix(int n) : base(n, n)
        {
            for (int i = 0; i < n; i++)
                this[i, i] = 1;
        }

        public static Matrix RotationX(float angle)
        {
            angle = (angle % 360) * (float)Math.PI / 180;
            Matrix res = new Matrix(3);

            res[1, 1] = (float)Math.Cos(angle);
            res[2, 2] = (float)Math.Cos(angle);

            res[1, 2] = (float)-Math.Sin(angle);
            res[2, 1] = (float)Math.Sin(angle);

            return res;
        }

        public static Matrix RotationY(float angle)
        {
            angle = (angle % 360) * (float)Math.PI / 180;
            Matrix res = new Matrix(3);

            res[0, 0] = (float)Math.Cos(angle);
            res[2, 2] = (float)Math.Cos(angle);

            res[0, 2] = (float)Math.Sin(angle);
            res[2, 0] = (float)-Math.Sin(angle);

            return res;
        }

        public static Matrix RotationZ(float angle)
        {
            angle = (angle % 360) * (float)Math.PI / 180;
            Matrix res = new Matrix(3);

            res[0, 0] = (float)Math.Cos(angle);
            res[1, 1] = (float)Math.Cos(angle);

            res[0, 1] = (float)-Math.Sin(angle);
            res[1, 0] = (float)Math.Sin(angle);

            return res;
        }

        public static Matrix GeneralRotation(int dim, int axisInd1, int axisInd2, float angle)
        {
            angle = (angle % 360) * (float)Math.PI / 180;
            Matrix res = new Matrix(dim);

            if (axisInd1 >= dim || axisInd2 >= dim) throw new DimensionException();

            res[axisInd1, axisInd1] = (float)Math.Cos(angle);
            res[axisInd2, axisInd2] = (float)Math.Cos(angle);
            res[axisInd1, axisInd2] = -(float)Math.Sin(angle);
            res[axisInd2, axisInd1] = (float)Math.Sin(angle);

            if ((axisInd1 + axisInd2) % 2 == 0)
            {
                res[axisInd1, axisInd2] *= -1;
                res[axisInd2, axisInd1] *= -1;
            }

            return res;
        }

        public static Matrix Rotation(float x, float y, float z)
            => Matrix.RotationX(x) * Matrix.RotationY(y) * Matrix.RotationZ(z);

        public float BilinearForm(Vector vector1, Vector vector2)
        {
            if (vector1.Rows != Rows || vector2.Rows != Cols || Rows != Cols) throw new DimensionException();

            float result = 0;

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    result += this[i, j] * vector1[i] * vector2[j];

            return result;
        }

        public static Matrix Gram(params Vector[] vectors)
        {
            int normal = vectors[0].Rows;
            for (int i = 1;i < vectors.Length; i++)
                if (vectors[i].Rows != normal) throw new DimensionException();

            Matrix result = new Matrix(vectors.Length, vectors.Length);

            for (int i = 0; i < result.Rows; i++)
                for (int j = 0; j < result.Cols; j++)
                    result[i, j] = vectors[i] % vectors[j];

            return result;
        }

        public float GetCofactor(int row, int col)
        {
            if (Rows != Cols) throw new DimensionException();

            Matrix minor = new Matrix(Rows - 1, Cols - 1);

            for (int k = 0; k < row; k++)
                for (int l = 0; l < col; l++)
                    minor[k, l] = this[k, l];

            for (int k = row + 1; k < Rows; k++)
                for (int l = col + 1; l < Cols; l++)
                    minor[k - 1, l - 1] = this[k, l];

            for (int k = row + 1; k < Rows; k++)
                for (int l = 0; l < col; l++)
                    minor[k - 1, l] = this[k, l];

            for (int k = 0; k < row; k++)
                for (int l = col + 1; l < Cols; l++)
                    minor[k, l - 1] = this[k, l];

            return minor.Determinant() * ((row + col) % 2 == 0 ? 1 : -1);
        }

        public float Determinant()
        {
            if (Rows != Cols) throw new DimensionException();

            if (Rows == 1) return this[0, 0];

            int nonZero = -1;

            for (int i = 0; i < Rows;i++)
            {
                if (this[i, 0] != 0)
                {
                    nonZero = i;
                    break;
                }
            }

            if (nonZero == -1) return 0;

            Matrix simple = new Matrix(Rows - 1, Cols - 1);

            for (int i = 0;i < nonZero; i++)
                for (int j = 0; j < Cols - 1;j++)
                    simple[i, j] = this[i, j + 1];

            for (int i = nonZero + 1; i < Rows; i++)
            {
                float simplyficationScalar = this[i, 0] / this[nonZero, 0];

                for (int j = 0; j < Cols - 1; j++)
                {
                    float simpleEl = this[i, j + 1]
                       - this[nonZero, j + 1] * simplyficationScalar;

                    simple[i - 1, j] = simpleEl;
                }
            }

            return this[nonZero, 0] * (nonZero % 2 == 0 ? 1 : -1) * simple.Determinant();
        }

        public Matrix Inverse()
        {
            if (Rows != Cols) throw new DimensionException();

            Matrix result = new Matrix(Rows, Cols);

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                {
                    result[i, j] = GetCofactor(i, j);
                }

            result.Transpose();
            result /= Determinant();
            return result;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows ||
                matrix1.Cols != matrix2.Cols) throw new DimensionException();

            Matrix result = new Matrix(matrix1.Rows, matrix1.Cols);

            for (int i = 0; i < matrix1.Rows; i++)
                for (int j = 0; j < matrix1.Cols; j++)
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
            
            return result;
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
            => matrix1 + (-1 * matrix2);

        public static Matrix operator *(Matrix matrix, float scalar)
        {
            Matrix result = new Matrix(matrix.Rows, matrix.Cols);
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Cols; j++)
                    result[i, j] = scalar * matrix[i, j];

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
            if (matrix1.Cols != matrix2.Rows) throw new DimensionException();

            Matrix result = new Matrix(matrix1.Rows, matrix2.Cols);

            for (int i = 0; i <  result.Rows; i++)
                for (int j = 0; j < result.Cols; j++)
                {
                    float elem = 0;

                    for (int k = 0; k < matrix1.Cols; k++)
                    {
                        elem += matrix1[i, k]  * matrix2[k, j];
                    }

                    result[i, j] = elem;
                }

            return result;
        }

        public static explicit operator Matrix(Vector vector)
        {
            Matrix res = new Matrix(vector.Rows, vector.Cols);
            for (int i = 0; i < res.Rows; i++)
                for (int j = 0; j < res.Cols; j++)
                    res[i, j] = vector[i, j];

            return res;
        }

        public static Matrix operator /(Matrix matrix1, Matrix matrix2)
            => matrix1 * matrix2.Inverse();

        public static Matrix operator *(Matrix matrix, Vector vector)
        {
            Matrix vectorMatrix = (Matrix)vector;
            return matrix * vectorMatrix;
        }

        public static Matrix operator *(Vector vector, Matrix matrix)
        {
            Matrix vectorMatrix = (Matrix)vector;
            return vectorMatrix * matrix;
        }
    }
}
