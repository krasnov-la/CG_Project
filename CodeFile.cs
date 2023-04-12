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
        /*VectorSpace vectorSpace = new VectorSpace(new Vector(1, 0, 0), new Vector(0, 1, 0), new Vector(0, 0, 1));*/
        Vector v1 = new Vector(1, 2, 6, 4, 9);
        Point point = new Point(8, 1, 3, 7, 3);
        Matrix matrix = new Matrix(new float[,] { { 2, 4, 1, 8 },
                                                      { 6, 8, 1, 5 },
                                                      { 3, 1, 7, 0 },
                                                      { 4, 9, 1, 2 } });

        Console.WriteLine(v1.Transposed());
        Console.WriteLine();
        Console.WriteLine(point.Transposed());
        Console.WriteLine();
        Console.WriteLine(matrix.Transposed());
    }

    //Class EngineExeption
    //Datatable indexators
    //Test Exeptions rework
}