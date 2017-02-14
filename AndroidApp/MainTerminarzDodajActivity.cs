using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AndroidApp
{
    [Activity(Label = "MainTerminarzDodajActivity")]
    public class MainTerminarzDodajActivity : Activity
    {
        private DateTime time2;
        private Button butData;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainTerminarzDodaj);
            ActionBar.Title = "Dodaj wydarzenie";
            EditText editTutul = (EditText) FindViewById(Resource.Id.tytul);

            EditText editTresc = (EditText) FindViewById(Resource.Id.tresc);
            butData = (Button) FindViewById(Resource.Id.buttoDodajWydarzenieDataPicker);
            Button butdodWyd = (Button) FindViewById(Resource.Id.buttoDodajWydarzenieAkceptacja);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            GetSharedPreferences("TylkoMkirko@", FileCreationMode.Private);
            string client = prefs.GetString("login", "null");


            butData.Click += DateSelect_OnClick;
            butdodWyd.Click += delegate
            {
                ServiceAgent agentCheck = new ServiceAgent();


                // LessonPlan plan = 
                agentCheck.ValidDodajWydarze(client, time2, editTutul.Text + ";" + editTresc.Text);


                var activity2 = new Intent(this, typeof(MainTerminarzActivity));
                Finish();
                StartActivity(activity2);
            };


            // Create your application here
        }

        void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate(DateTime time)
            {
                butData.Text = time.ToLongDateString();
                time2 = time;
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        public class DatePickerFragment : DialogFragment,
            DatePickerDialog.IOnDateSetListener
        {
            // TAG can be any string of your choice.
            public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();

            // Initialize this value to prevent NullReferenceExceptions.
            Action<DateTime> _dateSelectedHandler = delegate { };

            public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
            {
                DatePickerFragment frag = new DatePickerFragment();
                frag._dateSelectedHandler = onDateSelected;
                return frag;
            }

            public override Dialog OnCreateDialog(Bundle savedInstanceState)
            {
                DateTime currently = DateTime.Now;
                DatePickerDialog dialog = new DatePickerDialog(Activity,
                    this,
                    currently.Year,
                    currently.Month,
                    currently.Day);
                return dialog;
            }

            public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
            {
                // Note: monthOfYear is a value between 0 and 11, not 1 and 12!
                DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
                Log.Debug(TAG, selectedDate.ToLongDateString());
                _dateSelectedHandler(selectedDate);
            }
        }
    }
}