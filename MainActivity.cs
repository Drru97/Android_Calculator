using System;
using System.Globalization;
using Android.App;
using Android.Widget;
using Android.OS;

namespace Calculator
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button[] _buttons;
        private TextView _twOut;
        private string _operator;
        private double _firstValue;
        private bool _operationPressed;
        private bool _isDigit;
        private bool _pointPressed;
        private double _result;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.tLayout);
            // Initialize the array of the buttons
            _buttons = new[]
            {
                FindViewById<Button>(Resource.Id.button1), FindViewById<Button>(Resource.Id.button2),
                FindViewById<Button>(Resource.Id.button3), FindViewById<Button>(Resource.Id.button4),
                FindViewById<Button>(Resource.Id.button5), FindViewById<Button>(Resource.Id.button6),
                FindViewById<Button>(Resource.Id.button7), FindViewById<Button>(Resource.Id.button8),
                FindViewById<Button>(Resource.Id.button9), FindViewById<Button>(Resource.Id.button10),
                FindViewById<Button>(Resource.Id.button11), FindViewById<Button>(Resource.Id.button12),
                FindViewById<Button>(Resource.Id.button13), FindViewById<Button>(Resource.Id.button14),
                FindViewById<Button>(Resource.Id.button14), FindViewById<Button>(Resource.Id.button15),
                FindViewById<Button>(Resource.Id.button16), FindViewById<Button>(Resource.Id.button17)
            };
            // Initialize output text field
            _twOut = FindViewById<TextView>(Resource.Id.twOut);

            // Initialize comma button
            _buttons[0].Click += PointPressed;

            // Initialize zero button
            _buttons[1].Click += ZeroPressed;

            // Add event for digit buttons
            for (int i = 2; i < 11; i++)
                _buttons[i].Click += DigitPressed;

            // Add event for equals button pressed
            _buttons[11].Click += EqualsPressed;

            // Add event for operator button pressed
            for (int i = 12; i < 17; i++)
                _buttons[i].Click += OperatorPressed;

            // Add event for clear button pressed
            _buttons[17].Click += ClearPressed;
        }

        private void PointPressed(object sender, EventArgs e)
        {
            Button point = (Button)sender;
            // Check if point is not already typed and not the first sigh
            if (_pointPressed || _twOut.Text == string.Empty) return;
            _twOut.Text += point.Text;
            _pointPressed = true;
        }

        private void ZeroPressed(object sender, EventArgs e)
        {
            Button zero = (Button)sender;
            // Check if zero is not the first sign
            if (_twOut.Text != string.Empty)
                _twOut.Text += zero.Text;
            if (_twOut.Text == string.Empty && _operationPressed)
                _twOut.Text += zero.Text;
        }

        private void DigitPressed(object sender, EventArgs e)
        {
            Button digit = (Button)sender;
            _twOut.Text += digit.Text;
        }

        private void OperatorPressed(object sender, EventArgs e)
        {
            Button oper = (Button)sender;
            _operator = oper.Text;
            if (_twOut.Text == string.Empty) return;
            _firstValue = double.Parse(_twOut.Text);
            ClearPressed(sender, e);
            _operationPressed = true;
            _isDigit = true;
        }

        private void ClearPressed(object sender, EventArgs e)
        {
            _twOut.Text = string.Empty;
            _pointPressed = false;
            _operationPressed = false;
            _result = 0;
        }

        private void EqualsPressed(object sender, EventArgs e)
        {
            // Check if the sentence is correct
            if (_twOut.Text != string.Empty && _isDigit)
                try
                {
                    switch (_operator)
                    {
                        case "+":
                            _result = _firstValue + double.Parse(_twOut.Text);
                            break;
                        case "-":
                            _result = _firstValue - double.Parse(_twOut.Text);
                            break;
                        case "x":
                            _result = _firstValue * double.Parse(_twOut.Text);
                            break;
                        case "/":
                            _result = _firstValue / double.Parse(_twOut.Text);
                            break;
                    }
                }
                // Throws while division by zero
                catch (Exception)
                {
                    _twOut.Text = "@string/Infinity";
                }
            _twOut.Text = _result.ToString(CultureInfo.InvariantCulture);
            _result = 0;
        }
    }
}

