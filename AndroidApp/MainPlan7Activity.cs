using System;
using System.Collections;
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

namespace AndroidApp
{
    [Activity(Label = "MainPlan7Activity")]
    public class MainPlan7Activity : Activity
    {
        public class Lekcja
        {
            public string dzien;
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainPlan7);
            ActionBar.Title = "Plan na 12 dni";
            Button butGetPlan = (Button) FindViewById(Resource.Id.buttonGetPlan);
            ListView ListView = (ListView) FindViewById(Resource.Id.listViewPlan7);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            GetSharedPreferences("TylkoMkirko@", FileCreationMode.Private);
            string index = prefs.GetString("login", "null");

            ServiceAgent agent = new ServiceAgent();
            DateTime parsedDate;
            DateTime DateNow = DateTime.Now;
            string pattern = "YYYY-dd-MM";
            string now2 = String.Format("{0:yyyy-MM-dd}", DateNow);


            agent.ValidPlan7(index, now2);

            LessonPlan[] a = agent.GetPlan7();


            List<Lekcja> list = new List<Lekcja>();

            butGetPlan.Click += delegate
            {
                var uri = Android.Net.Uri.Parse("https://www.pwsz.wloclawek.pl/plan-zajec");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };


            var culture = new System.Globalization.CultureInfo("pl-PL");
            int t = 0;
            var day = "err";
            for (int x = 0; x < 12; x++)
            {
                if (a[x].Lessons.GetLength(0) != 0)
                {
                    day = a[x].Lessons[0].StartTime.ToString("dddd, dd MMMM", culture);
                    ;
                    day = day.ToUpper();
                    Lekcja l = new Lekcja();
                    l.dzien = "        " + day;


                    list.Add(l);
                    t++;

                    int ll = 1;
                    foreach (var zz in a[x].Lessons)
                    {
                        string temp = zz.LessonType;

                        Lekcja l2 = new Lekcja();
                        l2.dzien = ll + ". " + zz.LessonName + " " + System.Environment.NewLine + temp + " sala nr. " +
                                   zz.RoomNumber + " z " + zz.Instructor + System.Environment.NewLine +
                                   zz.StartTime.Hour + ":" + zz.StartTime.Minute + "-" + zz.EndTime.Hour + ":" +
                                   zz.EndTime.Minute;
                        ll++;

                        list.Add(l2);
                    }
                }
                else
                {
                    day = DateTime.Today.AddDays(t).ToString("dddd, dd MMMM", culture);
                    ;
                    Lekcja l = new Lekcja();
                    day = day.ToUpper();
                    l.dzien = "        " + day;
                    list.Add(l);
                    t++;
                }
            }

            string[] lista2 = new string[list.Count];
            int p = 0;
            foreach (var item in list)
            {
                lista2[p] = item.dzien;

                p++;
            }


            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,
                Android.Resource.Id.Text1, lista2);


            ListView.SetAdapter(adapter);

            // Create your application here
        }
    }
}