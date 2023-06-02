using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject
{
    public abstract class EngineExceptions : ApplicationException
    {
        public class OutOfTableException : ApplicationException
        {
            public OutOfTableException() : base("Indexes exceed data table dimensions") { }

        }

        public class DimensionException : ApplicationException
        {
            public DimensionException() : base("Operation invalid with current operand dimensions") { }
        }

        public class InvalidBasisException : ApplicationException
        {
            public InvalidBasisException() : base("Given set of vectors cannot be considered a basis") { }
        }

        public class PropertyTypeException : ApplicationException
        {
            public PropertyTypeException() : base("Trying to assign value of incorrect type to Entity property") { }
        }

        public class NonExistantPropertyException : ApplicationException
        {
            public NonExistantPropertyException() : base("Trying to operate on property that does't exist") { }
        }
    }
}
