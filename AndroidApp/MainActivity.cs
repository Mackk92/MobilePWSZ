using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Preferences;
using Android.Support.V4.App;
using Android.Views.Animations;
using Android.Widget;
using BazusApi;
using Environment = System.Environment;


namespace AndroidApp
{
    [Activity(Label = "Menu", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        private string PlanDetails;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            ActionBar bar = ActionBar;
            bar.SetBackgroundDrawable(new ColorDrawable(Color.Black));
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Main);

            ServiceAgent agentCheck = new ServiceAgent();

            // LessonPlan plan = 
            agentCheck.ValidPlanUpdate("Informatyka", "IV");

            string PlanUpdate = agentCheck.PlanUpdated;
            PlanDetails = PlanUpdate;
            if (PlanUpdate != "0")
            {
                addNotification();
                Toast.MakeText(this, "UWAGA ! Plan Zaktualizowany:  " + PlanUpdate, ToastLength.Long).Show();
            }


            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            GetSharedPreferences("TylkoMkirko@", FileCreationMode.Private);
            string client = prefs.GetString("login", "null");


            Toast.MakeText(this, "Zalogowano jako " + client, ToastLength.Long).Show();

            string login = Intent.GetStringExtra("login") ?? "Data not available";


            TextView nowTXT = (TextView) FindViewById(Resource.Id.TextNow);
            TextView nextTXT = (TextView) FindViewById(Resource.Id.TextNext);
            Button butUstaw = (Button) FindViewById(Resource.Id.buttonUstaw);
            Button butNews = (Button) FindViewById(Resource.Id.buttonNews);
            Button butWyl = (Button) FindViewById(Resource.Id.buttonWyloguj);
            Button butMaps = (Button) FindViewById(Resource.Id.buttonMapaUczelni);
            Button butPlan7 = (Button) FindViewById(Resource.Id.buttonPlan7);
            Button butTermi = (Button) FindViewById(Resource.Id.buttonTerminarz);
            Button butNav = (Button) FindViewById(Resource.Id.buttonNav);
            Button butKontakty = (Button) FindViewById(Resource.Id.buttonKontakty);

            ActionBar.Title = GetString(Resource.String.Welcome)+" " + login;
            
            DateTime now = DateTime.Now.ToLocalTime();

            AlphaAnimation buttonClick = new AlphaAnimation(1F, 0.8F);
            butKontakty.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainKontaktyDyzuryMainActivity));

                StartActivity(activity2);
            };
            butTermi.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainTerminarzActivity));

                StartActivity(activity2);
            };
            butNav.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainNawigacjaActivity));

                StartActivity(activity2);
            };

            butPlan7.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainPlan7Activity));

                StartActivity(activity2);
            };
            butMaps.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainMapaUczelniActivity));

                StartActivity(activity2);
            };

            butUstaw.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainUstawieniaActivity));

                StartActivity(activity2);
            };

            butWyl.Click += delegate
            {
                ISharedPreferences prefs3 = PreferenceManager.GetDefaultSharedPreferences(this);
                GetSharedPreferences("TylkoMkirko@", FileCreationMode.Private);

                ISharedPreferencesEditor editor = prefs.Edit();

                editor.PutString(("login"), null);
                editor.PutString("password", null);
                editor.PutString("email", null);
                editor.Apply();
                var activity2 = new Intent(this, typeof(LoginActivity));

                StartActivity(activity2);
                Finish();
            };
            butNews.Click += delegate
            {
                var activity2 = new Intent(this, typeof(MainNewsActivity));

                StartActivity(activity2);
            };


            ServiceAgent agent = new ServiceAgent();

            // LessonPlan plan = 
            agent.ValidPlan(login, now);

            LessonPlan kek = agent.GetPlan();
            foreach (Lesson l in kek.Lessons)
            {
                if (l.SpecialtyId.Equals("NOW"))
                {
                    nowTXT.Text = l.LessonName + Environment.NewLine + "Rozpoczêcie:" + l.StartTime + " Zakoñczenie" +
                                  l.EndTime + "Sala:" + l.RoomNumber +
                                  Environment.NewLine + l.Instructor;
                }
                if (l.SpecialtyId.Equals("NEXT"))
                {
                    nextTXT.Text = l.LessonName + Environment.NewLine + " Rozpoczêcie:" + l.StartTime + " Zakoñczenie" +
                                   l.EndTime + "Sala:" + l.RoomNumber +
                                   Environment.NewLine + l.Instructor;
                }
                else
                {
                    //nextTXT.Text = "brak";
                }
            }
        }


        private void addNotification()
        {
            // Instantiate the builder and set notification elements:
            Notification.Builder builder = new Notification.Builder(this)
                .SetContentTitle("Zmina planu !")
                .SetContentText("Uwaga nast¹pi³a zmiana Twojego plany " + PlanDetails)
                .SetSmallIcon(Resource.Drawable.Icon);

            // Build the notification:
            Notification notification = builder.Build();

            // Get the notification manager:
            NotificationManager notificationManager =
                GetSystemService(Context.NotificationService) as NotificationManager;

            // Publish the notification:
            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);
        }
    }
}