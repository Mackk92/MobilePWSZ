using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BazusApi;
using MobilePWSZService;

namespace AndroidApp
{
    [Activity(Label = "MainTerminarz")]
    public class MainTerminarzActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainTerminarz);
            // Create your application here

            ActionBar.Title = "Terminarz ";
            ListView ListView = (ListView) FindViewById(Resource.Id.listTerminarz);
            Button butdodWyd = (Button) FindViewById(Resource.Id.buttoDodajWydarzenie);
            Button butgetSesja = (Button) FindViewById(Resource.Id.buttonGeSesja);
            Button butgetHarmonogram = (Button) FindViewById(Resource.Id.buttonGeHarmo);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            GetSharedPreferences("TylkoMkirko@", FileCreationMode.Private);
            string index = prefs.GetString("login", "null");

            ServiceAgent agent = new ServiceAgent();
            butdodWyd.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainTerminarzDodajActivity));

                StartActivity(activity2);
            };
            butgetHarmonogram.Click += delegate
            {
                var uri = Android.Net.Uri.Parse("https://www.pwsz.wloclawek.pl/organizacja-roku-akademickiego");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };
            butgetSesja.Click += delegate
            {
                var uri = Android.Net.Uri.Parse("https://www.pwsz.wloclawek.pl/sesja-egzaminacyjna");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };
            agent.ValidGetWydarzenia(index);

            wydarzenia[] a = agent.GetWyd();

            string[] lista2 = new string[a.Length];
            int r = 0;
            foreach (var tt in a)
            {
                string temp3 = tt.data.ToString("MM/dd/yyyy HH:mm:ss.fff",
                    CultureInfo.InvariantCulture);
                lista2[r] = tt.id_wydarzenia.ToString() + System.Environment.NewLine + temp3 +
                            System.Environment.NewLine + tt.tytul + System.Environment.NewLine + tt.tresc;
                r++;
            }
            List<wydarzenia> list = new List<wydarzenia>();
            var culture = new System.Globalization.CultureInfo("pl-PL");
            int t = 0;
            var day = "err";


            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,
                Android.Resource.Id.Text1, lista2);


            ListView.SetAdapter(adapter);
        }
    }
}