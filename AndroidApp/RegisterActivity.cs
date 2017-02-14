using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Preferences;
using Android.Views;
using Android.Widget;


namespace AndroidApp
{
    [Activity(Label = "Rejestracja", ScreenOrientation = ScreenOrientation.Portrait)]
    public class RegisterActivity : Activity
    {
        private int RegisterCheck = 1;
        private int RegisterValidCheck = 1;
        private int Blad = 1;
        async Task RegisterMethod(String login, String haslo1, String haslo2, String mail, bool zap)
        {
            await Task.Run(() =>
            {
                // Do long running stuff here   
                try
                {
                    ServiceAgent agent = new ServiceAgent();
                    ProgressDialog progress = new ProgressDialog(this);
                    bool check = true;
                    if (String.IsNullOrEmpty(login) | String.IsNullOrEmpty(haslo1) |
                        String.IsNullOrEmpty(haslo1) | String.IsNullOrEmpty(mail))
                    {
                        check = false;
                        RegisterValidCheck = 0;
                    }

                    if ((haslo1 != haslo2) | haslo1.Length<6)
                    {
                        check = false;
                        RegisterValidCheck = 0;
                    }
                    if (check)
                    {
                        // progress.SetCancelable(false); // disable dismiss by tapping outside of the dialog
                        //  ProgressDialog.Show(this, "£¹czenie", "Proszê czkaæ...");

                        agent.ValidRegister(login, haslo1, mail);
                    }
                    Toast.MakeText(this, agent.validCheck.ToString() + "", ToastLength.Long).Show();
                    if (agent.validCheck & check)
                    {
                        if (zap)
                        {
                            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                            GetSharedPreferences("TylkoMkirko@", FileCreationMode.Private);
                            ISharedPreferencesEditor editor = prefs.Edit();

                            editor.PutString(("login"), login);

                            editor.PutString("email", mail);


                            ServiceAgent agentMR1 = new ServiceAgent();

                            agentMR1.ValidHash(login, haslo1);

                            editor.Apply();
                            editor.PutString("password", agentMR1.passHash);
                        }


                        var activity2 = new Intent(this, typeof(MainActivity));
                        activity2.PutExtra("login", login);
                        progress.Dismiss();
                        StartActivity(activity2);
                        Finish();
                    }
                    else
                    {
                        progress.Dismiss();
                        RegisterCheck = 0;
                    }
                }
                catch (Exception e)
                {
                    Blad = 0;
                }
            });
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);

            EditText login = (EditText) FindViewById(Resource.Id.index);
            EditText haslo1 = (EditText) FindViewById(Resource.Id.pass1);
            EditText haslo2 = (EditText) FindViewById(Resource.Id.pass2);
            EditText email = (EditText) FindViewById(Resource.Id.email);
            View RegView = (View) FindViewById(Resource.Id.LoginView);
            Button butRej = (Button) FindViewById(Resource.Id.buttonRej);
            ProgressBar probar = (ProgressBar) FindViewById(Resource.Id.progress);
            CheckBox zap = (CheckBox) FindViewById(Resource.Id.checkZapamR);
            ServiceAgent agent = new ServiceAgent();
            ActionBar.Title = "Rejestracja";
            probar.Visibility = ViewStates.Gone;
            probar.IndeterminateDrawable.SetColorFilter(Color.ParseColor("#ff0000"),
                Android.Graphics.PorterDuff.Mode.SrcAtop);

            butRej.Click += async delegate
            {
                probar.Visibility = ViewStates.Visible;
                RegView.Visibility = ViewStates.Gone;
                await RegisterMethod(login.Text, haslo1.Text, haslo2.Text, email.Text, zap.Checked);
                probar.Visibility = ViewStates.Gone;
                RegView.Visibility = ViewStates.Visible;
                if (RegisterCheck == 0)
                {
                    Toast.MakeText(this, "Z³y Indeks  lub Has³o", ToastLength.Long).Show();
                }
                if (RegisterValidCheck == 0)
                {
                    Toast.MakeText(this, "Pola nie zosta³y wype³nione prawid³owo ! Has³o musi mieæ minimum 6 znaków .", ToastLength.Long).Show();
                }
                if (Blad == 0)
                {
                    Toast.MakeText(this, "B³¹d logowanie (Ju¿ siê rejestrowa³eœ ?)", ToastLength.Long).Show();
                }
            };
        }
    }
}