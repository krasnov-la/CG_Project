using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CGProject
{
    namespace Math
    {
        public class Matrix : DataTable
        {
            public Matrix(int rows, int cols) : base(rows, cols) { }

            public Matrix(float[,] data) : base(data.GetLength(0), data.GetLength(1))
            {
                for (int i = 0; i < Rows; i++)
                    for (int j = 0; j < Cols; j++)
                        this[i, j] = data[i, j];
            }

            public Matrix(int n) : base(n, n)
            {
                for (int i = 0; i < n; i++)
                    this[i, i] = 1;
            }

            public static Matrix RotationX(float angle)
                => GeneralRotation(3, 1, 2, angle);

            public static Matrix RotationY(float angle)
                => GeneralRotation(3, 0, 2, angle);

            public static Matrix RotationZ(float angle)
                => GeneralRotation(3, 0, 1, angle);

            public static Matrix GeneralRotation(int dim, int axisInd1, int axisInd2, float angle)
            {
                angle = (angle % 360) * (float)System.Math.PI / 180;
                Matrix res = new Matrix(dim);

                if (axisInd1 >= dim || axisInd2 >= dim) throw new EngineExceptions.DimensionException();

                res[axisInd1, axisInd1] = (float)System.Math.Cos(angle);
                res[axisInd2, axisInd2] = (float)System.Math.Cos(angle);
                res[axisInd1, axisInd2] = -(float)System.Math.Sin(angle);
                res[axisInd2, axisInd1] = (float)System.Math.Sin(angle);

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
                if (vector1.Rows != Rows || vector2.Rows != Cols || Rows != Cols) throw new EngineExceptions.DimensionException();

                float result = 0;

                for (int i = 0; i < Rows; i++)
                    for (int j = 0; j < Cols; j++)
                        result += this[i, j] * vector1[i] * vector2[j];

                return result;
            }

            public static Matrix Gram(params Vector[] vectors)
            {
                int normal = vectors[0].Rows;
                for (int i = 1; i < vectors.Length; i++)
                    if (vectors[i].Rows != normal) throw new EngineExceptions.DimensionException();

                Matrix result = new Matrix(vectors.Length, vectors.Length);

                for (int i = 0; i < result.Rows; i++)
                    for (int j = 0; j < result.Cols; j++)
                        result[i, j] = vectors[i] % vectors[j];

                return result;
            }


            public Matrix Minor(int row, int col)
            {
                if (Rows != Cols) throw new EngineExceptions.DimensionException();

                Matrix minor = new Matrix(Rows - 1, Cols - 1);

                for (int k = 0; k < Rows; k++)
                    for (int l = 0; l < Cols; l++)
                        if (k != row && l != col)
                        {
                            int i = k > row ? k - 1 : k;
                            int j = l > col ? l - 1 : l;
                            minor[i, j] = this[k, l];
                        }

                return minor;
            }

            public float GetCofactor(int row, int col)
            {
                Matrix minor = this.Minor(row, col);

                float res;

                if (minor.Rows == 1)
                    res = minor[0, 0];
                else
                    res = minor.Determinant();

                return res * ((row + col) % 2 == 0 ? 1 : -1);
            }

            public float Determinant()
            {
                if (Rows != Cols) throw new EngineExceptions.DimensionException();

                float res = 0;

                for (int i = 0; i < Rows; i++)
                    res += this[i, 0] * GetCofactor(i, 0);

                return res;
            }

            public Matrix Inverse()
            {
                if (Rows != Cols) throw new EngineExceptions.DimensionException();

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

            public static Matrix Sum(Matrix matrix1, Matrix matrix2)
            {
                if (matrix1.Rows != matrix2.Rows ||
                    matrix1.Cols != matrix2.Cols) throw new EngineExceptions.DimensionException();

                Matrix result = new Matrix(matrix1.Rows, matrix1.Cols);

                for (int i = 0; i < matrix1.Rows; i++)
                    for (int j = 0; j < matrix1.Cols; j++)
                        result[i, j] = matrix1[i, j] + matrix2[i, j];

                return result;
            }

            public static Matrix ScalarMult(float scalar, Matrix matrix)
            {
                Matrix result = new Matrix(matrix.Rows, matrix.Cols);
                for (int i = 0; i < matrix.Rows; i++)
                    for (int j = 0; j < matrix.Cols; j++)
                        result[i, j] = scalar * matrix[i, j];

                return result;
            }

            public static Matrix MatrixMult(Matrix matrix1, Matrix matrix2)
            {
                if (matrix1.Cols != matrix2.Rows) throw new EngineExceptions.DimensionException();

                Matrix result = new Matrix(matrix1.Rows, matrix2.Cols);

                for (int i = 0; i < result.Rows; i++)
                    for (int j = 0; j < result.Cols; j++)
                    {
                        float elem = 0;

                        for (int k = 0; k < matrix1.Cols; k++)
                        {
                            elem += matrix1[i, k] * matrix2[k, j];
                        }

                        result[i, j] = elem;
                    }

                return result;
            }

            public static Matrix ConvFromVectror(Vector vector)
            {
                Matrix res = new Matrix(vector.Rows, vector.Cols);
                for (int i = 0; i < res.Rows; i++)
                    for (int j = 0; j < res.Cols; j++)
                        res[i, j] = vector[i, j];

                return res;
            }

            public static Matrix operator +(Matrix matrix1, Matrix matrix2)
                => Sum(matrix1, matrix2);

            public static Matrix operator -(Matrix matrix1, Matrix matrix2)
                => matrix1 + (-1 * matrix2);

            public static Matrix operator *(Matrix matrix, float scalar)
                => ScalarMult(scalar, matrix);

            public static Matrix operator *(float scalar, Matrix matrix)
                => ScalarMult(scalar, matrix);

            public static Matrix operator /(Matrix matrix, float scalar)
                => ScalarMult(1 / scalar, matrix);


            public static Matrix operator *(Matrix matrix1, Matrix matrix2)
                => MatrixMult(matrix1, matrix2);

            public static explicit operator Matrix(Vector vector)
                => ConvFromVectror(vector);

            public static Matrix operator /(Matrix matrix1, Matrix matrix2)
                => matrix1 * matrix2.Inverse();

            public static Matrix operator *(Matrix matrix, Vector vector)
                => MatrixMult(matrix, ConvFromVectror(vector));

            public static Matrix operator *(Vector vector, Matrix matrix)
                => MatrixMult(ConvFromVectror(vector), matrix);
        }
    }
}
