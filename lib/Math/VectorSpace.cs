namespace CGProject.Math
{
    public class VectorSpace
    {
        Vector[] _basis;

        public Vector[] Basis
        { get { return _basis; } }

        public VectorSpace(params Vector[] basis)
        {
            if (!IsValidBasis(basis)) throw new EngineExceptions.InvalidBasisException();
            _basis = basis;
        }

        public Vector VectorProduct(Vector vector1, Vector vector2)
        {
            if (vector1.Rows != 3 || vector2.Rows != 3) throw new EngineExceptions.DimensionException();

            Vector result = new(3);

            result += Basis[0] * (vector1[1] * vector2[2] -
                                  vector1[2] * vector2[1]);

            result += Basis[1] * (vector1[2] * vector2[0] -
                                  vector1[0] * vector2[2]);

            result += Basis[2] * (vector1[0] * vector2[1] -
                                  vector1[1] * vector2[0]);

            return result;
        }

        public static bool IsValidBasis(Vector[] basis)
        {
            if (basis.Length == 0) return false;

            int dim = basis[0].Size;
            if (basis.Length != dim) return false;
            
            Matrix matrix = new(dim);
            
            for (int i = 0; i < dim; i++)
            {
                if (basis[i].Size != dim) return false;
                if (basis[i].IsTransposed()) basis[i].Transpose();
            
                for (int j = 0; j < dim; j++)
                {
                    matrix[i, j] = basis[i][j];
                }
            }
            return !(matrix.Determinant() == 0);
        }

        public float ScalarProduct(Vector vector1, Vector vector2)
        {
            if (vector1.IsTransposed() || vector2.IsTransposed() ||
                vector1.Size != vector2.Size) throw new EngineExceptions.DimensionException();
            return (vector1.Transposed() * Matrix.Gram(_basis) * vector2)[0, 0];
        }

        public float Length(Vector vector)
        {
            return (float)System.Math.Sqrt(ScalarProduct(vector, vector));
        }

        public Vector AsBaseVector(Point point)
        {
            if (point.IsTransposed()) point.Transpose();

            if (point.Rows != _basis[0].Rows) throw new EngineExceptions.DimensionException();

            Vector result = new(_basis[0].Rows);

            for (int i = 0; i < _basis.Length; i++)
                result += _basis[i] * point[i];

            return result;
        }

        public Vector Normalize(Vector vector)
        {
            return vector / Length(vector);
        }

        public Vector AsVectorInBasis(Point point)
        {
            Vector vector = new Vector(3);
            for (int i = 0; i < 3; i++)
            {
                vector[i] = point[i];
            }
            Matrix basisSwap = new Matrix(Basis.Length);

            for (int i = 0; i < Basis.Length; i++)
                for (int j = 0; j < Basis.Length; j++)
                {
                    basisSwap[i, j] = Basis[j][i];
                }

            Matrix InvSwap = basisSwap.Inverse();

            return (Vector)(InvSwap * vector);
        }
    }
}