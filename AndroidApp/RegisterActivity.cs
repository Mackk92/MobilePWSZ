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
        public int RegisterCheck = 1;
        public int RegisterValidCheck = 1;
        public int Blad = 1;
        public string Kierunek = "";
        public string Rok = "";
        private void spinner_ItemSelected1(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string Temp43 = string.Format("{0}", spinner.GetItemAtPosition(e.Position));

            Rok = Temp43;

        }


        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string Temp43 = string.Format("{0}", spinner.GetItemAtPosition(e.Position));

            Kierunek = Temp43;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);

            EditText loginM = (EditText) FindViewById(Resource.Id.index);

            EditText emailM = (EditText) FindViewById(Resource.Id.email);
            View RegView = (View) FindViewById(Resource.Id.LoginView);
            Button butRej = (Button) FindViewById(Resource.Id.buttonRej);
            ProgressBar probar = (ProgressBar) FindViewById(Resource.Id.progress);
            
            ServiceAgent agent = new ServiceAgent();
            ActionBar.Title = "Rejestracja";
            probar.Visibility = ViewStates.Gone;
            probar.IndeterminateDrawable.SetColorFilter(Color.ParseColor("#ff0000"),
                Android.Graphics.PorterDuff.Mode.SrcAtop);
          
            loginM.TextChanged += (sender, e) =>
            {
                emailM.Text = loginM.Text+"@pwsz.wloclawek.pl";
            };

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.kierunki_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            spinner.SetSelection(0);

            Spinner spinner1 = FindViewById<Spinner>(Resource.Id.spinner1);
            spinner1.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected1);
            var adapter1 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.rok_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner1.Adapter = adapter1;
            spinner1.SetSelection(0);




            butRej.Click += async delegate
            {
                Toast.MakeText(this, "Proszê czekaæ ...", ToastLength.Long).Show();
                probar.Visibility = ViewStates.Visible;
                RegView.Visibility = ViewStates.Gone;
                String login = loginM.Text;
                String haslo1= "admin1";
                String haslo2 = "admin1";
                String mail=emailM.Text;
                bool zap = false;
                try
                {
                    ServiceAgent agent1 = new ServiceAgent();
                    ProgressDialog progress = new ProgressDialog(this);
                    bool check = true;
                    if (String.IsNullOrEmpty(login) | String.IsNullOrEmpty(haslo1) |
                        String.IsNullOrEmpty(haslo1) | String.IsNullOrEmpty(mail))
                    {
                        check = false;
                        RegisterValidCheck = 0;
                    }

                    if ((haslo1 != haslo2) | haslo1.Length < 6)
                    {
                        check = false;
                        RegisterValidCheck = 0;
                    }
                    if (check)
                    {
                        // progress.SetCancelable(false); // disable dismiss by tapping outside of the dialog
                        //  ProgressDialog.Show(this, "£¹czenie", "Proszê czkaæ...");
                        Toast.MakeText(this, Kierunek + ";" + Rok, ToastLength.Long).Show();
                        await agent.ValidRegister(login, Kierunek + ";"+Rok, mail);
             

                        Toast.MakeText(this, "Has³o zosta³o wys³ane na maila.", ToastLength.Long).Show();


                    }
                    
                   
                }
                catch (Exception e)
                {
                    Blad = 0;
                }
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