using System;

using UIKit;

namespace ChinLang.iOS
{
    public partial class ViewController : UIViewController
    {
        TranslateClass translateClass;

        public ViewController(IntPtr handle) : base(handle)
        {
            this.translateClass = new TranslateClass();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            UIPickerViewModel pickerViewModel = new UIPickerViewModel();
            //SP::Assign the dictioanry keys to the picker
            /*
https://github.com/xamarin/ios-samples/blob/master/MonoCatalog-MonoDevelop/PickerViewController.xib.cs
https://stackoverflow.com/questions/36510230/xamarin-ios-uipickerview-tutorial
            */
            foreach(String key in translateClass.dictionaries.Keys){
                //LangPicker.Add(key);
            }
            UITapGestureRecognizer gestureRecognizer = new UITapGestureRecognizer(() => translateClass.ChangeDirection());
            gestureRecognizer.NumberOfTapsRequired = 2;
            TextBoxOne.AddGestureRecognizer(gestureRecognizer);
            TextBoxTwo.AddGestureRecognizer(gestureRecognizer);
            TextBoxOne.Changed += (object sender, EventArgs e) =>
            {
                TextBoxTwo.Text = translateClass.TranslateString(TextBoxOne.ToString(), LangPicker.ToString());
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

    }
}
