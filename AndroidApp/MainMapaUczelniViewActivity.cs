using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;

namespace AndroidApp
{
    [Activity(Label = "MainMapViewActivity")]
    public class MainMapaUczelniViewActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //SetContentView(Resource.Layout.);
            SetContentView(Resource.Layout.MainMapaUczelniView);
            ActionBar.Title = "Plan piêtra";
            ScaleImageView img = (ScaleImageView) FindViewById(Resource.Id.ImageViewPlan);
            // ImageView img = (ImageView) FindViewById(Resource.Id.ImageViewPlan);
            Button butWroc = (Button) FindViewById(Resource.Id.buttonWroc);
            ActionBar.Title = "Plan ";

            butWroc.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainMapaUczelniActivity));

                StartActivity(activity2);
                Finish();
            };

            string imgRS = Intent.GetStringExtra("img") ?? "Data not available";

            if (imgRS == "MechPiwnica")
            {
                img.SetImageResource(Resource.Drawable.MechPiwnica);
            }
            if (imgRS == "MechParter")
            {
                img.SetImageResource(Resource.Drawable.MechParter);
            }
            if (imgRS == "MechI")
            {
                img.SetImageResource(Resource.Drawable.MechI);
            }
            if (imgRS == "MechII")
            {
                img.SetImageResource(Resource.Drawable.MechII);
            }
            if (imgRS == "MechIII")
            {
                img.SetImageResource(Resource.Drawable.MechIII);
            }
            if (imgRS == "MechIV")
            {
                img.SetImageResource(Resource.Drawable.MechIV);
            }
            if (imgRS == "ZawDomStud")
            {
                img.SetImageResource(Resource.Drawable.ZawDomStud);
            }
            if (imgRS == "ZawParter")
            {
                img.SetImageResource(Resource.Drawable.ZawParter);
            }
            if (imgRS == "ZawI")
            {
                img.SetImageResource(Resource.Drawable.ZawI);
            }
            if (imgRS == "ZawII")
            {
                img.SetImageResource(Resource.Drawable.ZawII);
            }
            // Create your application here
        }
    }
}