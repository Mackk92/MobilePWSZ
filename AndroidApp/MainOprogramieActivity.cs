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
    [Activity(Label = "MainOprogramieActivity")]
    public class MainOprogramieActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

          
            SetContentView(Resource.Layout.MainOprogramie);
            
            // Create your application here
            ActionBar.Title = "O programie";
        }
    }
}