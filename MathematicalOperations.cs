using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Calculator
{
    public static class MathematicalOperations
    {
        public static double Addition(double lhs, double rhs)
        {
            return lhs + rhs;
        }

        public static double Subtraction(double lhs, double rhs)
        {
            return lhs - rhs;
        }

        public static double Multiplication(double lhs, double rhs)
        {
            return lhs * rhs;
        }

        public static double Division(double lhs, double rhs)
        {
            if (rhs == 0.0)
                throw new DivideByZeroException("Divide by zero");
            return lhs / rhs;
        }

    }
}