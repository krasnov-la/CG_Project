﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    public abstract class DataTable
    {
        float[,] _data;
        bool _transpose = false;

        public DataTable(int rows, int cols)
        {
            _data = new float[rows, cols];
        }

        public int Rows
        {
            get
            {
                if (_transpose) return _data.GetLength(1);
                else return _data.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                if (_transpose) return _data.GetLength(0);
                else return _data.GetLength(1);
            }
        }

        public virtual float this[int i, int j]
        {
            get { return GetElem(i, j); }
            set { SetElem(i, j, value);}
        }


        protected void SetElem(int row, int col, float value)
        {
            if (row < 0 || col < 0 || row >= Rows || col >= Cols) throw new OutOfTableException();
            if (_transpose) _data[col, row] = value;
            else _data[row, col] = value;
        }

        protected float GetElem(int row, int col)
        {
            if (row < 0 || col < 0 || row >= Rows || col >= Cols) throw new OutOfTableException();
            if (_transpose) return _data[col, row];
            else return _data[row, col];
        }

        public void Transpose()
        {
            _transpose = !_transpose;
        }

        public bool IsTransposed()
            => _transpose;

        public sealed override string ToString()
        {
            string result = "";

            for (int i = 0; i < Rows; i++)
            {
                for (int  j = 0; j < Cols; j++)
                {
                    result += this[i, j] + " ";
                }
                
                result = result.Remove(result.Length - 1, 1);
                result += "\n";
            }
            
            result = result.Remove(result.Length - 1, 1);

            return result;
        }

    }
}
