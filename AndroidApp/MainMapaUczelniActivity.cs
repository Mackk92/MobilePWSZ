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
    [Activity(Label = "MainMapaUczelniActivity")]
    public class MainMapaUczelniActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ActionBar.Title = "Mapa Budynków";
            // Create your application here

            SetContentView(Resource.Layout.MainMapaUczelni);
            ActionBar.Title = "Mapa Uczelni";


            Button butMechPiwinca = (Button) FindViewById(Resource.Id.buttonPiwnica);
            Button butMechParter = (Button) FindViewById(Resource.Id.buttonParter);
            Button butMechI = (Button) FindViewById(Resource.Id.buttonIpietro);
            Button butMechII = (Button) FindViewById(Resource.Id.buttonIIpietro);
            Button butMechIII = (Button) FindViewById(Resource.Id.buttonIIIpietro);
            Button butMechIV = (Button) FindViewById(Resource.Id.buttonIVpietro);
            Button butZawDomStud = (Button) FindViewById(Resource.Id.buttonZawDomStud);
            Button butZawParter = (Button) FindViewById(Resource.Id.buttonZawparter);
            Button butZawI = (Button) FindViewById(Resource.Id.buttonZawIpietro);
            Button butZawII = (Button) FindViewById(Resource.Id.buttonZawIIpietro);


            butMechPiwinca.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainMapaUczelniViewActivity));
                activity2.PutExtra("img", "MechPiwnica");
                StartActivity(activity2);
            };
            butMechParter.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainMapaUczelniViewActivity));
                activity2.PutExtra("img", "MechParter");
                StartActivity(activity2);
            };
            butMechI.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainMapaUczelniViewActivity));
                activity2.PutExtra("img", "MechI");
                StartActivity(activity2);
            };
            butMechII.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainMapaUczelniViewActivity));
                activity2.PutExtra("img", "MechII");
                StartActivity(activity2);
            };
            butMechIII.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainMapaUczelniViewActivity));
                activity2.PutExtra("img", "MechIII");
                StartActivity(activity2);
            };
            butMechIV.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainMapaUczelniViewActivity));
                activity2.PutExtra("img", "MechIV");
                StartActivity(activity2);
            };
            butZawDomStud.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainMapaUczelniViewActivity));
                activity2.PutExtra("img", "ZawDomStud");
                StartActivity(activity2);
            };
            butZawParter.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainMapaUczelniViewActivity));
                activity2.PutExtra("img", "ZawParter");
                StartActivity(activity2);
            };
            butZawI.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainMapaUczelniViewActivity));
                activity2.PutExtra("img", "ZawI");
                StartActivity(activity2);
            };
            butZawII.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainMapaUczelniViewActivity));
                activity2.PutExtra("img", "ZawII");
                StartActivity(activity2);
            };
        }
    }
}