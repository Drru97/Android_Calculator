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

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.tLayout);
            // Initialize the array of the buttons
            _buttons = new[] { FindViewById<Button>(Resource.Id.button1), FindViewById<Button>(Resource.Id.button2),
                                FindViewById<Button>(Resource.Id.button3), FindViewById<Button>(Resource.Id.button4),
                                FindViewById<Button>(Resource.Id.button5), FindViewById<Button>(Resource.Id.button6),
                                FindViewById<Button>(Resource.Id.button7), FindViewById<Button>(Resource.Id.button8),
                                FindViewById<Button>(Resource.Id.button9), FindViewById<Button>(Resource.Id.button10),
                                FindViewById<Button>(Resource.Id.button11), FindViewById<Button>(Resource.Id.button12),
                                FindViewById<Button>(Resource.Id.button13), FindViewById<Button>(Resource.Id.button1),
                                FindViewById<Button>(Resource.Id.button14), FindViewById<Button>(Resource.Id.button15),
                                FindViewById<Button>(Resource.Id.button16), FindViewById<Button>(Resource.Id.button17) };
            // Initialize output text field
            _twOut = FindViewById<TextView>(Resource.Id.twOut);
            // Add event for digit buttons
            for (int i = 0; i < 11; i++)
                AddDigit(_buttons[i]);
        }

        void AddDigit(Button button)
        {
            button.Click += delegate { _twOut.Text += button.Text; };
        }
    }
}

