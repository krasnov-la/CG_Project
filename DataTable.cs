using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    abstract class DataTable
    {
        float[,] _data;
        int _rows;
        int _cols;
        bool _transpose = false;

        public DataTable(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;
            _data = new float[rows, cols];
        }

        public int Rows
        {
            get
            {
                if (_transpose) return _cols;
                else return _rows;
            }
        }

        public int Cols
        {
            get
            {
                if (_transpose) return _rows;
                else return _cols;
            }
        }

        public void SetElem(int row, int col, float value)
        {
            if (_transpose) _data[col, row] = value;
            else _data[row, col] = value;
        }

        public float GetElem(int row, int col)
        {
            if (_transpose) return _data[col, row];
            else return _data[row, col];
        }

        public sealed override string ToString()
        {
            string result = "";

            for (int i = 0; i < Rows; i++)
            {
                for (int  j = 0; j < Cols; j++)
                {
                    result += GetElem(i, j) + " ";
                }
                
                result.Remove(result.Length - 1, 1);
                result += "\n";
            }
            
            result.Remove(result.Length - 1, 1);

            return result;
        }

    }
}
