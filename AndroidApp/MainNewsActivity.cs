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
using MobilePWSZService;

namespace AndroidApp
{
    [Activity(Label = "MainNewsActivity")]
    public class MainNewsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainNews);
            // Create your application here
            ActionBar.Title = "News";

            TextView news1 = (TextView) FindViewById(Resource.Id.TxtNews1);
            TextView news2 = (TextView) FindViewById(Resource.Id.TxtNews2);

            TextView news3 = (TextView) FindViewById(Resource.Id.TxtNews3);
            TextView news4 = (TextView) FindViewById(Resource.Id.TxtNews4);

            TextView news5 = (TextView) FindViewById(Resource.Id.TxtNews5);
            TextView news6 = (TextView) FindViewById(Resource.Id.TxtNews6);

            ServiceAgent agent = new ServiceAgent();
            agent.ValidNews();

            News[] a = agent.GetNewss();

            try
            {
                news1.Text = a[0].komunikat;
                news2.Text = a[1].komunikat;
                news3.Text = a[2].komunikat;
                news4.Text = a[3].komunikat;
                news5.Text = a[4].komunikat;
                news6.Text = a[5].komunikat;
            }
            catch (Exception e)
            {
                news1.Text = "Serwer nie odpowiada ...";
                news2.Text = "Serwer nie odpowiada ...";
                news3.Text = "Serwer nie odpowiada ...";
                news4.Text = "Serwer nie odpowiada ...";
                news5.Text = "Serwer nie odpowiada ...";
                news6.Text = "Serwer nie odpowiada ...";
            }
        }
    }
}