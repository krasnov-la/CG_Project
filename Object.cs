using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    class Object
    {
        protected Point _center;
        protected Vector _rotation;
        public bool Contains(Point point) { return false; }
    }
}
