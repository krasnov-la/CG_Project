using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    public class OutOfTableExeption : ApplicationException
    {
        public OutOfTableExeption() : base("Indexes exeed data table dimensions") { }
    }

    public class DimensionExeption : ApplicationException
    {
        public DimensionExeption() : base("Operation invalid with current operand dimensions") { }
    }

    public class EmptyBasisExeption : ApplicationException
    {
        public EmptyBasisExeption() : base("Basis can not be empty") { }
    }
}
