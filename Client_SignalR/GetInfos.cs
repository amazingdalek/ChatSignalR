
    using System;  
    using System.Collections.Generic;  
    using System.Linq;  
    using System.Text;
using Android;
using Android.App;  
    using Android.Content;  
    using Android.OS;  
    using Android.Runtime;  
    using Android.Util;  
    using Android.Views;  
    using Android.Widget;  
      
    namespace Client_SignalR  
    {  
        public class GetInfo : DialogFragment  
        {  
            public class OnGetInfoCompleteEventArgs : EventArgs  
            {  
                public string TxtName { get; set; }  
                public int BackgroundColor { get; set; }  
            }  
            public event EventHandler<OnGetInfoCompleteEventArgs> OnGetInfoComplete;  
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)  
            {  
                // Use this to return your custom view for this Fragment  
                // return inflater.Inflate(Resource.Layout.YourFragment, container, false);  
      
                View view = inflater.Inflate(Resource.Layout.getinfos, container, false);  
                EditText txtName = view.FindViewById<EditText>(Resource.Id.txtName);  
                Button btnOkay = view.FindViewById<Button>(Resource.Id.btnOkay);  
                RadioGroup radioGroup = view.FindViewById<RadioGroup>(Resource.Id.radioGroup);  
      
                btnOkay.Click += (o, e) =>  
                {  
                    var args = new OnGetInfoCompleteEventArgs { TxtName = txtName.Text.Trim() };  
                    switch (radioGroup.CheckedRadioButtonId)  
                    {  
                        case Resource.Id.radioRed:  
                            args.BackgroundColor = 1;  
                            break;  
                        case Resource.Id.radioGreen:  
                            args.BackgroundColor = 2;  
                            break;  
                        case Resource.Id.radioBlue:  
                            args.BackgroundColor = 3;  
                            break;  
                    }  
                    OnGetInfoComplete.Invoke(this, args);  
      
                    Dismiss();  
                };  
                return view;  
            }  
            public override void OnActivityCreated(Bundle savedInstanceState)  
            {  
                Dialog.Window.RequestFeature(WindowFeatures.NoTitle);  
                base.OnActivityCreated(savedInstanceState);  
            }  
        }  
    }  
