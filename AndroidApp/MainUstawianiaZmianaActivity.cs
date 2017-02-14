using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidApp
{
    [Activity(Label = "MainUstawianiaZmiana")]
    public class MainUstawianiaZmianaActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MainUstawieniaZmiana);
            ActionBar.Title = GetString(Resource.String.Change_Password);
            EditText index = (EditText) FindViewById(Resource.Id.index);

            ISharedPreferences prefs1 = PreferenceManager.GetDefaultSharedPreferences(this);
            GetSharedPreferences("TylkoMkirko@", FileCreationMode.Private);
            string loginMR = prefs1.GetString("login", null);
            if (!String.IsNullOrEmpty(loginMR))
            {
                index.Text = loginMR;
                index.Enabled = false;
            }

            EditText hasloOld = (EditText) FindViewById(Resource.Id.stareHaslo);
            EditText hasloNowe1 = (EditText) FindViewById(Resource.Id.noweHaslo1);
            EditText hasloNowe2 = (EditText) FindViewById(Resource.Id.noweHaslo2);
            Button butRes = (Button) FindViewById(Resource.Id.buttonZmienHaslo);

            ServiceAgent agent = new ServiceAgent();

            butRes.Click += delegate
            {
              
               
                    bool check = true;


                    if (String.IsNullOrEmpty(index.Text) | String.IsNullOrEmpty(hasloOld.Text) |
                        String.IsNullOrEmpty(hasloNowe1.Text) | String.IsNullOrEmpty(hasloNowe2.Text))
                    {
                       
                        check = false;
                        // Toast.MakeText(this, "Wype³nij wszystkie pola", ToastLength.Long).Show();
                    }
                    if (hasloNowe1.Text != hasloNowe2.Text)
                    {
                        
                        // Toast.MakeText(this, "Nowe has³a nie s¹ takie same", ToastLength.Long).Show();
                        check = false;
                    }
                    if (check)
                    {
                        agent.ValidReset(index.Text, null, hasloOld.Text + ";" + hasloNowe2.Text);
                    }


                    if (agent.validCheck & check)
                    {
                        ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                        GetSharedPreferences("TylkoMkirko@", FileCreationMode.Private);
                        ISharedPreferencesEditor editor = prefs.Edit();

                        editor.PutString(("login"), index.Text);

                        // z hs z bazy 
                        ServiceAgent agentMR1 = new ServiceAgent();
                        RunOnUiThread(
                            () => Toast.MakeText(this, "Toast within progress dialog.", ToastLength.Long).Show());
                        agentMR1.ValidHash(index.Text, hasloNowe1.Text);
                        string temp = agentMR1.passHash;

                        editor.PutString("password", temp);
                        editor.Apply();

                        Toast.MakeText(this, "Has³o zosta³o zmienione", ToastLength.Long).Show();
                        var activity2 = new Intent(this, typeof(MainActivity));
                        activity2.PutExtra("login", index.Text);

                        
                        StartActivity(activity2);
                        Finish();
                    }
                    else
                    {
                        
                        Toast.MakeText(this, "Reset has³a nie powiód³ siê ...", ToastLength.Long).Show();
                    }
               
            };
        }
    }
}