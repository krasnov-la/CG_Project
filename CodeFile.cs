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
        /*VectorSpace vectorSpace = new VectorSpace(new Vector(1, 0, 0), new Vector(0, 1, 0), new Vector(0, 0, 1));
        Vector v1 = new Vector(1, 6, 7);
        Vector v2 = new Vector(2, 1, 3);
        Console.WriteLine(v1 % v2);*/

        Console.WriteLine(Matrix.RotationX(90));
        Console.WriteLine(Matrix.GeneralRotation(3, 1, 2, 90));
    }

    //Class EngineExeption
    //Datatable indexators
    //Test Exeptions rework
}