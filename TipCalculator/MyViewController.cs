using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TipCalculator
{
    class MyViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = UIColor.Yellow;

            UITextField BillAmount = new UITextField(new CGRect(20, 35, View.Bounds.Width - 40, 25))
            {
                Placeholder = "Enter Bill Amount",
                KeyboardType = UIKeyboardType.DecimalPad,
                BorderStyle = UITextBorderStyle.RoundedRect
            };

            UIButton CalculateButton = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(20, 35 + 25 + 8, View.Bounds.Width - 40, 35),
                BackgroundColor = UIColor.FromRGB(0, 0.5f, 0),

            };

            CalculateButton.SetTitle("Calculate", UIControlState.Normal);

            UILabel ResultText = new UILabel(new CGRect(20, 35 + 25 + 8 + 35 + 8, View.Bounds.Width - 40, 25))
            {
                Text = "Tip: $0.00",
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.Blue              
            };

            CalculateButton.TouchUpInside += delegate (object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(BillAmount.Text))
                {
                    BillAmount.ResignFirstResponder();
                    double Value = 0;
                    double.TryParse(BillAmount.Text, out Value);
                    ResultText.Text = string.Format("Tip is {0:C}", Value * 0.15);
                }
                else
                {
                    BillAmount.Text = "Please Enter Amount First";
                    BillAmount.TextColor = UIColor.Red;
                    return;
                }
            };
        }
        
    }
}