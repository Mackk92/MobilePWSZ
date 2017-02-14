using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using Android.OS;
using Android.Preferences;
using Android.Views;
using Javax.Security.Auth;


namespace AndroidApp
{
    [Activity( Icon = "@drawable/icon",
         ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginActivity : Activity
    {
        private ProgressBar mProgress;
        private int mProgressStatus = 0;
        private int LoginCheck = 1;

        async Task LoginMethod(String login, String haslo, bool zap)
        {
            await Task.Run(() =>
            {
                // Do long running stuff here   


                ServiceAgent agent = new ServiceAgent();
                // ProgressDialog progress = new ProgressDialog(this);
                //  progress.SetCancelable(false); // disable dismiss by tapping outside of the dialog
                // ProgressDialog.Show(this, "Łączenie", "Proszę czkać...");


                //  var progressDialog = ProgressDialog.Show(this, "Please wait...", "Checking account info...", true);
                //  new Thread(new ThreadStart(delegate
                //  {
                // RunOnUiThread(() => Toast.MakeText(this, "Toast within progress dialog.", ToastLength.Long).Show());
                try
                {
                    agent.ValidLogin(login, haslo, null);
                }
                catch (Exception e)
                {
                    //   Toast.MakeText(this, "Zły Indeks  lub Hasło", ToastLength.Long).Show();
                    LoginCheck = 0;
                }
                // Toast.MakeText(this, agent.validCheck.ToString() + "" + haslo.Text, ToastLength.Long).Show();
                if (agent.validCheck)
                {
                    if (zap)
                    {
                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                        GetSharedPreferences("TylkoMkirko@", FileCreationMode.Private);
                        ISharedPreferencesEditor editor = prefs.Edit();

                        editor.PutString(("login"), login);

                        // z hs z bazy 
                        ServiceAgent agentMR1 = new ServiceAgent();

                        agentMR1.ValidHash(login, haslo);
                        string temp = agentMR1.passHash;

                        editor.PutString("password", temp);
                        editor.Apply();
                    }
                    ISharedPreferences prefs11 = PreferenceManager.GetDefaultSharedPreferences(this);
                    GetSharedPreferences("TylkoMkirko@", FileCreationMode.Private);
                    ISharedPreferencesEditor editor1 = prefs11.Edit();
                    editor1.Apply();

                    editor1.PutString(("login"), login);
                    editor1.Apply();

                    //RunOnUiThread(() => progressDialog.Hide());
                    var activity2 = new Intent(this, typeof(MainActivity));
                    activity2.PutExtra("login", login);

                    StartActivity(activity2);
                    Finish();
                }
                else
                {
                    // RunOnUiThread(() => progressDialog.Hide());
                    // Toast.MakeText(this, "Zły Indeks  lub Hasło", ToastLength.Long).Show();


                    // Toast.MakeText(Application.Context, "Adele : Hello from the other thread...", ToastLength.Short).Show();
                    LoginCheck = 0;
                    //set alert for executing the task
                }
            });
        }

        protected override void OnCreate(Bundle bundle)
        {
            ActionBar bar = ActionBar;
            bar.SetBackgroundDrawable(new ColorDrawable(Color.Black));

            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Login);


            ISharedPreferences prefs1 = PreferenceManager.GetDefaultSharedPreferences(this);
            GetSharedPreferences("TylkoMkirko@", FileCreationMode.Private);
            string psssMR = prefs1.GetString("password", null);
            string logMR = prefs1.GetString("login", null);

            if (!String.IsNullOrEmpty(psssMR))
            {
                ServiceAgent agentMR = new ServiceAgent();
                agentMR.ValidLogin(logMR, null, psssMR);

                if (agentMR.validCheck)
                {
                    var activity2 = new Intent(this, typeof(MainActivity));
                    activity2.PutExtra("login", logMR);
                    StartActivity(activity2);
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "Wystąpił bład, zaloguj się manualnie", ToastLength.Long).Show();
                }
            }
            else
            {
                //Toast.MakeText(this, "nie zapisane ", ToastLength.Long).Show();
            }


            // agent.Valid(null, null, null);


            View LoginView = (View) FindViewById(Resource.Id.LoginView);
            EditText login = (EditText) FindViewById(Resource.Id.index);
            EditText haslo = (EditText) FindViewById(Resource.Id.pass);

            Button butLog = (Button) FindViewById(Resource.Id.buttonLog);
            Button butRej = (Button) FindViewById(Resource.Id.buttonRej);
            TextView butRes = (TextView) FindViewById(Resource.Id.buttonReset);
            CheckBox zap = (CheckBox) FindViewById(Resource.Id.checkZapam);
            ProgressBar probar = (ProgressBar) FindViewById(Resource.Id.progress);

            
            probar.Visibility = ViewStates.Gone;
            probar.IndeterminateDrawable.SetColorFilter(Color.ParseColor("#ff0000"),
                Android.Graphics.PorterDuff.Mode.SrcAtop);

            butLog.Click += async delegate
            {
                probar.Visibility = ViewStates.Visible;
                LoginView.Visibility = ViewStates.Gone;
                await LoginMethod(login.Text, haslo.Text, zap.Checked);
                probar.Visibility = ViewStates.Gone;
                LoginView.Visibility = ViewStates.Visible;
                if (LoginCheck == 0)
                {
                    Toast.MakeText(this, "Zły Indeks  lub Hasło", ToastLength.Long).Show();
                }


                //})).Start();
            };
            butRej.Click += delegate
            {
                //Toast.MakeText(this, login.Text + "--" + haslo.Text, ToastLength.Long).Show();


                var activity2 = new Intent(this, typeof(RegisterActivity));
                activity2.PutExtra("login", login.Text);
                activity2.PutExtra("haslo", haslo.Text);
                StartActivity(activity2);
            };
            butRes.Click += delegate
            {
                // Toast.MakeText(this, login.Text + "--" + haslo.Text, ToastLength.Long).Show();



                var activity21 = new Intent(this, typeof(ResetActivity));
                activity21.PutExtra("login", login.Text);
                activity21.PutExtra("haslo", haslo.Text);
                StartActivity(activity21);
            };
        }
    }
}