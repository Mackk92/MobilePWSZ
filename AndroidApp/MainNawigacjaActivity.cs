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
    [Activity(Label = "MainNawigacjaActivity")]
    public class MainNawigacjaActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainNawigacja);
            // Create your application here
            ActionBar.Title = "Nawigacja";
            Button but3maj = (Button) FindViewById(Resource.Id.buttoNav3Maja);
            Button butmech3 = (Button) FindViewById(Resource.Id.buttonNavMech3);
            Button butwisla = (Button) FindViewById(Resource.Id.buttoNavWisla21);

            ScaleImageView img = (ScaleImageView) FindViewById(Resource.Id.ImageViewPlan);

            but3maj.Click += delegate
            {
                var uri = Android.Net.Uri.Parse("geo:0,0?q=3 Maja 17, 87-800 W³oc³awek");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };
            butmech3.Click += delegate
            {
                var uri = Android.Net.Uri.Parse("geo:0,0?q=Mechaników 3, W³oc³awek");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };
            butwisla.Click += delegate
            {
                var uri = Android.Net.Uri.Parse("geo:0,0?q=Obroñców Wis³y 1920 r. 25");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };
        }
    }
}