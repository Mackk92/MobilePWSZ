using System;
using System.Net;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Java.IO;

namespace AndroidApp
{
    [Activity(Label = "KontaktyDyzuryActivity")]
    public class MainKontaktyDyzuryActivity : Activity
    {
        //private ScaleImageView _img;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainKontaktyDyzury);
            ActionBar.Title = ActionBar.Title = GetString(Resource.String.Dyzury);
            // _img = (ScaleImageView)FindViewById(Resource.Id.ImageDyzury);
            //_img.Visibility = ViewStates.Invisible;
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.dyzury_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            spinner.SetSelection(0);



        //    WebView localWebView = FindViewById<WebView>(Resource.Id.LocalWebView);
        //    localWebView.SetWebViewClient(new WebViewClient());
         //   localWebView.LoadUrl("https://www.pwsz.wloclawek.pl/2013-05-10-07-29-18/plan-zajec");

        }

      


            // File path2 = Android.OS.Environment.GetInternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments);
          
          
        
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string Temp43 = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
            
            if (Temp43== "Zak³ad Administracji")
            {
        
                WebView localWebView = FindViewById<WebView>(Resource.Id.LocalWebView);
                localWebView.Settings.JavaScriptEnabled = true;
                String pdf = "https://www.pwsz.wloclawek.pl/images/Wykaz_dyzurow_sesja_zimowa_A_16-17.pdf";
                localWebView.LoadUrl("http://drive.google.com/viewerng/viewer?embedded=true&url=" + pdf);
            }
            if (Temp43 == "Zak³ad Zarz¹dzania")
            {
                WebView localWebView = FindViewById<WebView>(Resource.Id.LocalWebView);
                localWebView.Settings.JavaScriptEnabled = true;
                String pdf = "https://www.pwsz.wloclawek.pl/images/zarz%C4%85dzanie_2016-17.pdf";
                localWebView.LoadUrl("http://drive.google.com/viewerng/viewer?embedded=true&url=" + pdf);
            }
            if (Temp43 == "Zak³ad Informatyki")
            { 
               
                WebView localWebView = FindViewById<WebView>(Resource.Id.LocalWebView);
                localWebView.Settings.JavaScriptEnabled = true;
                String pdf = "https://www.pwsz.wloclawek.pl/images/informatyka_2016-17.pdf";
                localWebView.LoadUrl("http://drive.google.com/viewerng/viewer?embedded=true&url=" + pdf);
            }
            if (Temp43 == "Zak³ad Mechaniki i budowy maszyn")
            {
                // var uri = Android.Net.Uri.Parse("https://www.pwsz.wloclawek.pl/images/Wykaz_dy%C5%BCur%C3%B3w_sem._zimowy_16-17_MiBM.pdf");
                // var intent = new Intent(Intent.ActionView, uri);
                // StartActivity(intent);
                // WebView localWebView = FindViewById<WebView>(Resource.Id.LocalWebView);
                //localWebView.Settings.JavaScriptEnabled = true;
                // String pdf = "https://www.pwsz.wloclawek.pl/images/Wykaz_dy%C5%BCur%C3%B3w_sesja_zimowa_16-17_MiBM.pdf";
                //localWebView.LoadUrl("http://drive.google.com/viewerng/viewer?embedded=true&url=" + pdf);
                Toast.MakeText(this, "Dy¿ury dla tego zak³adu bêd¹ dostêpne wkrótce ", ToastLength.Long).Show();
            }
            if (Temp43 == "Instytut Nauk o Zdrowiu")
            {
                Toast.MakeText(this, "Dy¿ury dla tego zak³adu bêd¹ dostêpne wkrótce ", ToastLength.Long).Show();
            }
            if (Temp43 == "Studium Wychowania Fizycznego i Sportu")
            {
          
                WebView localWebView = FindViewById<WebView>(Resource.Id.LocalWebView);
                localWebView.Settings.JavaScriptEnabled = true;
                String pdf = "https://www.pwsz.wloclawek.pl/images/student/Dy%C5%BCury_semestr_2016-17_lato.pdf";
                localWebView.LoadUrl("http://drive.google.com/viewerng/viewer?embedded=true&url=" + pdf);
            }
            if (Temp43 == "Zak³ad Filologii Angielskiej, Pedagogiki, kierunku Nowe media i e-biznes oraz Studium Jêzyków Obcych")
            {
                WebView localWebView = FindViewById<WebView>(Resource.Id.LocalWebView);
                localWebView.Settings.JavaScriptEnabled = true;
                String pdf = "https://www.pwsz.wloclawek.pl/images/Dy%C5%BCury_SESJA_zima_16-17_3.pdf";
                localWebView.LoadUrl("http://drive.google.com/viewerng/viewer?embedded=true&url=" + pdf);
          
            }


        }



    }
    }
