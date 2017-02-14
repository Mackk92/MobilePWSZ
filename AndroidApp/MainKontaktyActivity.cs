using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace AndroidApp
{
    [Activity(Label = "MainKontaktyActivity")]
    public class MainKontaktyActivity : Activity
    {
       


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainKontakty);
            ActionBar.Title = "Kontakty ";
            // Create your application here

       
           
           
        }
    }
}