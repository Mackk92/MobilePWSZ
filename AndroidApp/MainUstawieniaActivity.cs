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

namespace AndroidApp
{
    [Activity(Label = "MainUstawieniaActivity")]
    public class MainUstawieniaActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            // Create your application here
            SetContentView(Resource.Layout.MainUstawienia);
            ActionBar.Title = GetString(Resource.String.Settings);
            Button butZmiana = (Button) FindViewById(Resource.Id.buttonZmianaHasla);
            butZmiana.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainUstawianiaZmianaActivity));

                StartActivity(activity2);
            };
        }
    }
}