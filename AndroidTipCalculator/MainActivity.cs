using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AndroidTipCalculator
{
    [Activity(Label = "AndroidTipCalculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Find controls for manipulation
            var totalBillBeforeTip = FindViewById<EditText>(Resource.Id.txtTotalBeforeTip);

            //var taxRate = FindViewById<EditText>(Resource.Id.txtTaxRate);

            RadioGroup radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            RadioButton tipPercent = FindViewById<RadioButton>(radioGroup.CheckedRadioButtonId);
            RadioButton tenPercent = FindViewById<RadioButton>(Resource.Id.rdoTenPercent);
            RadioButton fifteenPercent = FindViewById<RadioButton>(Resource.Id.rdoFifteenPercent);
            RadioButton eighteenPercent = FindViewById<RadioButton>(Resource.Id.rdoEighteenPercent);
            RadioButton twentyPercent = FindViewById<RadioButton>(Resource.Id.rdoTwentyPercent);

            //var tip = FindViewById<TextView>(Resource.Id.lblTip);

            //var grandTotal = FindViewById<TextView>(Resource.Id.lblGrandTotal);


            // EVENTS
            totalBillBeforeTip.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                CalculateAll();
            };

            tenPercent.Click += RadioTipPercentClick;
            fifteenPercent.Click += RadioTipPercentClick;
            eighteenPercent.Click += RadioTipPercentClick;
            twentyPercent.Click += RadioTipPercentClick;
        }

        private void RadioTipPercentClick(object sender, EventArgs e)
        {
            CalculateAll();
        }

        public void CalculateAll()
        {
            var totalBillBeforeTip = FindViewById<EditText>(Resource.Id.txtTotalBeforeTip);

            var taxRate = FindViewById<EditText>(Resource.Id.txtTaxRate);

            RadioGroup radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            RadioButton tipPercent = FindViewById<RadioButton>(radioGroup.CheckedRadioButtonId);

            var tip = FindViewById<TextView>(Resource.Id.lblTip);

            var grandTotal = FindViewById<TextView>(Resource.Id.lblGrandTotal);

            // If there is an amount in the total bill, then calculate the tip.
            // Otherwise, remove the amounts in tip and grand total
            if (totalBillBeforeTip.Text.Length > 0)
            {
                tip.Text = string.Format("{0:#.00}", (float.Parse(totalBillBeforeTip.Text) * (float.Parse(tipPercent.Text) / 100.0)));

                grandTotal.Text = string.Format("{0:#.00}", (float.Parse(totalBillBeforeTip.Text) + float.Parse(tip.Text)));
            }
            else
            {
                tip.Text = "";
                grandTotal.Text = "";
            }

        }
    }
}

