using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG_Project;

class Program
{
    static void Main(string[] args)
    {
        float[,] data = { {5, 1, 7, 1 }, 
                          {1, 9, 1, 6 },  
                          {8, 3, 2, 7 }, 
                          {9, 1, 1, 6 }, };

        float[] dataV = { 1, 2, 3, 4 };

        Matrix M = new Matrix(data);
        Console.WriteLine((M * M.Inverse()).ToString());
    }
}