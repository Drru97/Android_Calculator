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
    class CalculatorLogic
    {
        public double FirstValue { get; set; }
        public double SecondValue { get; set; }
        public string Operator { get; set; }
        public double Result { get; set; }

        enum OperationType
        {
            Addition = '+',
            Subtraction = '-',
            Multiplication = '*',
            Division = '/'
        };

        private bool _firstValueInput;
        private bool _operatorInput;
        private bool _secondValueInput;
        private bool _readyToClear;
        private bool _errorCatched;

        public CalculatorLogic()
        {

        }

        public void Calculate()
        {
            if (!_firstValueInput || !_secondValueInput) return;
            switch (Operator)
            {
                case "+":
                    Result = MathematicalOperations.Addition(FirstValue, SecondValue);
                    break;
                case "-":
                    Result = MathematicalOperations.Subtraction(FirstValue, SecondValue);
                    break;
                case "*":
                    Result = MathematicalOperations.Multiplication(FirstValue, SecondValue);
                    break;
                case "/":
                    try
                    {
                        Result = MathematicalOperations.Division(FirstValue, SecondValue);
                    }
                    catch (DivideByZeroException)
                    {
                        _errorCatched = true;
                        // throw;  // commented for future
                    }
                    break;
                default:
                    _errorCatched = true;
                    break;
            }
        }
    }
}