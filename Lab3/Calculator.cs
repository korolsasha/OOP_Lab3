using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Calculator
    {
        public decimal Add(decimal op1, decimal op2)
        {
            return op1 + op2;
        }

        public decimal Substract(decimal op1, decimal op2)
        {
            return op1 - op2;
        }
        public decimal Multiply(decimal op1, decimal op2)
        {
            return op1 * op2;
        }
        public decimal Divide(decimal op1, decimal op2)
        {
            return op1 / op2;
        }
    }
}
