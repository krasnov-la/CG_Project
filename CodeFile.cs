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

        float[] data1 = { 2, 1, 4 };
        float[] data2 = { 1, 6, 3 };

        Vector v1 = new Vector(data1);
        Vector v2 = new Vector(data2);
        Console.WriteLine(v1 % v2);
    }
}