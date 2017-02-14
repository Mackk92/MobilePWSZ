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
    [Activity(Label = "MainKontaktyDyzuryMainActivity")]
    public class MainKontaktyDyzuryMainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainKontaktyDyzuryMain);
            Button butDyz = (Button)FindViewById(Resource.Id.buttonDyzuryMain);
            Button butKon = (Button)FindViewById(Resource.Id.buttonKontaktyMain);
            // Create your application here
            ActionBar.Title = "Kontakty i Dy¿ury";
            butDyz.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainKontaktyDyzuryActivity));

                StartActivity(activity2);
            };

            butKon.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainKontaktyActivity));

                StartActivity(activity2);
            };
        }

    }
}