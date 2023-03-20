using Microsoft.VisualBasic;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{ 

    /*class Camera
    {
        public Point pos;
        public bool hold;
        public Vector dir;
        public byte compress = 255;
        public float fov = 170;
        public float dist = 50;
        public float vert_fov_ratio = 0.2f; //v_fov = ratio * fov 

        public Camera(Point cam_pos, Vector cam_dir, bool target_hold)
        {
            this.pos = cam_pos;
            this.hold = target_hold;
            this.dir = !cam_dir;
        }

        public Camera(Point cam_pos, Point target, bool target_hold)
        {
            this.pos = cam_pos;
            this.hold = target_hold;
            this.dir = !(new Vector(target));
        }

        public void Move(float x, float y, float z)
        {
            this.pos = this.pos + new Point(x, y, z);
        }

        public void RayCast(int hor_dots) //@ $ # * ! = ; : ~ - , . (' ')
        {
            *//*Queue cast = new Queue();
            // горизонтальный вектор по экрану z = 0; x * pos.x + y * pos.y = 0; x^2 + y^2 = 1; решаем систему
            int vert_dots = (int)(hor_dots * vert_fov_ratio);
            float hor_y = (float)Math.Sqrt(1 / ((dir.y * dir.y) / (dir.x * dir.x) + 1));
            float hor_x = -1 * dir.y * hor_y / dir.x;
            float screen_half_width = (float)Math.Tan(this.fov * Math.PI / 360);
            float screen_half_height = screen_half_width * this.vert_fov_ratio;
            Vector hor_v = new Vector(hor_x, hor_y, 0);
            Vector vert_v = dir ^ hor_v;
            Point screen_travel = this.pos + this.dir;

            char[,] screen = new char[hor_dots, vert_dots];

            if (vert_v.z < 0) //проверка тройки и инверсия для парвильного заполнения
            {                  // с верху в низ с лева на право 
                hor_v = hor_v * -1;
                vert_v = dir ^ hor_v;
            }

            screen_travel = screen_travel + hor_v * screen_half_width + vert_v * screen_half_height;
            hor_v = hor_v * -1;
            vert_v = vert_v * -1;

            for(int i = 0;i < hor_dots;i++)
            {
                for (int j = 0;j < vert_dots;j++)
                {
                    //Console.WriteLine((screen_travel + hor_v * ((2 * i + 1) * screen_half_width / hor_dots) + vert_v * ((2 * j + 1) * screen_half_height / vert_dots)).str());
                    cast.Enqueue(screen_travel + hor_v * ((2 * i + 1) * screen_half_width / hor_dots) + vert_v * ((2 * j + 1) * screen_half_height / vert_dots));
                }
            }

            for (int i =  0;i < hor_dots;i++)
            {
                for (int j = 0;j < vert_dots;j++)
                {
                    Point ray_Point = (Point)cast.Dequeue();
                    Vector ray_Vector = !(new Vector(ray_Point - this.pos));
                    Point next_point = ray_Point + ray_Vector;

                    screen[i, j] = ' ';

                    while ((ray_Point & next_point) <= this.dist) // big_cast
                    {
                        dynamic curr_obj = VectorSpace.map[next_point.IntApprox().Str()];
                        if (curr_obj != null)
                        {
                            next_point = next_point - ray_Vector;
                            Vector small_ray = ray_Vector / 16;

                            for (int k = 1; k <= 16; k++)
                            {
                                if (curr_obj.t_contain(next_point + (small_ray * k)))
                                {
                                    Point intersect = next_point + (small_ray * k);
                                    float casted = intersect & ray_Point;
                                    if (100 * casted >= this.dist * 91) screen[i, j] = '.';
                                    else if (100 * casted >= this.dist * 83) screen[i, j] = ',';
                                    else if (100 * casted >= this.dist * 75) screen[i, j] = '-';
                                    else if (100 * casted >= this.dist * 66) screen[i, j] = '~';
                                    else if (100 * casted >= this.dist * 58) screen[i, j] = ':';
                                    else if (100 * casted >= this.dist * 50) screen[i, j] = ';';
                                    else if (100 * casted >= this.dist * 41) screen[i, j] = '=';
                                    else if (100 * casted >= this.dist * 33) screen[i, j] = '!';
                                    else if (100 * casted >= this.dist * 25) screen[i, j] = '*';
                                    else if (100 * casted >= this.dist * 16) screen[i, j] = '#';
                                    else if (100 * casted >= this.dist * 8) screen[i, j] = '$';
                                    else screen[i, j] = '@';
                                    next_point = next_point + ray_Vector * (this.dist + 1);
                                    break;
                                }
                            }

                            next_point = next_point + ray_Vector;
                        }

                        next_point = next_point + ray_Vector;
                    }
                }
            }

            for (int i = 0;i < vert_dots;i++)
            {
                for (int j = 0;j < hor_dots;j++)
                {
                    Console.Write(screen[j, i]);
                }
                Console.Write('|');
                Console.Write('\n');
            }
        }*//*
        }
    }

    class obj
    {
        
    }*/


    internal class Program
    {
        /*static void Main(string[] args)
        {
            Point a = new Point(1, 2, 3);
            Point b = new Point(3, 4, 5);
            Point c = a + b;
            Vector v1 = new Vector(1, 1, 1);
            Vector v2 = new Vector(2, 2, 2);

            
        }*/
    }
}
