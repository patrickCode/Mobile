using Android.App;
using Android.Widget;
using Android.OS;

namespace TipCalculator
{
    [Activity(Label = "Tip Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        EditText inputBill;
        Button calculateButton;
        TextView outputTip;
        TextView outputTtotal;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
             SetContentView (Resource.Layout.Main);

            inputBill = FindViewById<EditText>(Resource.Id.inputBill);
            calculateButton = FindViewById<Button>(Resource.Id.caclculateButton);
            outputTip = FindViewById<TextView>(Resource.Id.ouputTip);
            outputTtotal = FindViewById<TextView>(Resource.Id.outputTotal);

            calculateButton.Click += CalculateButton_Click;
        }

        private void CalculateButton_Click(object sender, System.EventArgs e)
        {
            var billStr = inputBill.Text;

            var bill = double.Parse(billStr);

            var tip = bill * 0.15;
            var total = bill + tip;

            outputTip.Text = tip.ToString();
            outputTtotal.Text = total.ToString();
        }
    }
}