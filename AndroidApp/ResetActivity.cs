using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Color = Android.Graphics.Color;

namespace AndroidApp
{
    [Activity(Label = "Reset has豉", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ResetActivity : Activity
    {
        private int ResCheck = 1;
        private int ResValidCheck = 1;

        async Task ResetMethod(String index, String email)
        {
            await Task.Run(() =>
            {
                ServiceAgent agent = new ServiceAgent();
                // Do long running stuff here   

                bool check = true;


                if (String.IsNullOrEmpty(index) | String.IsNullOrEmpty(email))
                {
                    check = false;
                    ResValidCheck = 0;
                }
                if (check)
                {
                    agent.ValidReset(index, email, null);
                }


                if (agent.validCheck & check)
                {
                    var activity2 = new Intent(this, typeof(LoginActivity));

                    StartActivity(activity2);
                    Finish();
                    ResCheck = 3;
                }
                else
                {
                    ResCheck = 0;
                }
            });
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Reset);


            ActionBar.Title = "Reset has豉";
            View ResView = (View)FindViewById(Resource.Id.LoginView);
            EditText index = (EditText)FindViewById(Resource.Id.index);
            EditText email = (EditText)FindViewById(Resource.Id.email);
            Button butRes12 = (Button)FindViewById(Resource.Id.buttonReset21);
            ProgressBar probar = (ProgressBar)FindViewById(Resource.Id.progress);
            probar.IndeterminateDrawable.SetColorFilter(Color.ParseColor("#ff0000"),
                Android.Graphics.PorterDuff.Mode.SrcAtop);

            butRes12.Click += async delegate
            {
                probar.Visibility = ViewStates.Visible;
                ResView.Visibility = ViewStates.Gone;
                await ResetMethod(index.Text, email.Text);
                probar.Visibility = ViewStates.Gone;
                ResView.Visibility = ViewStates.Visible;
                if (ResCheck == 0)
                {
                    Toast.MakeText(this, "Z造 Indeks  lub Has這", ToastLength.Long).Show();
                }
                if (ResCheck == 3)
                {
                    Toast.MakeText(this, "Nowe Has這 zosta這 wys豉ne na:" + index + "@pwsz.wloclawek.pl", ToastLength.Long).Show();
                }
            };
        }
    }
}