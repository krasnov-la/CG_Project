using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    public abstract class EngineExceptions
    {
        public class OutOfTableException : ApplicationException
        {
            public OutOfTableException() : base("Indexes exceed data table dimensions") { }

        }

        public class DimensionException : ApplicationException
        {
            public DimensionException() : base("Operation invalid with current operand dimensions") { }
        }

        public class EmptyBasisException : ApplicationException
        {
            public EmptyBasisException() : base("Basis can not be empty") { }
        }
    }
}
