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
            ActionBar.Title = "Dy¿ury";
            // _img = (ScaleImageView)FindViewById(Resource.Id.ImageDyzury);
            //_img.Visibility = ViewStates.Invisible;
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.dyzury_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            spinner.SetSelection(0);

        }

      


            // File path2 = Android.OS.Environment.GetInternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments);
          
          
        
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string Temp43 = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
            
            if (Temp43== "Zak³adu Administracji")
            {
                var uri = Android.Net.Uri.Parse("https://www.pwsz.wloclawek.pl/images/Wykaz_dyzurow_sem._zimowy_16-17.pdf");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            }
            if (Temp43 == "Zak³adu Zarz¹dzania")
            {
                var uri = Android.Net.Uri.Parse("https://www.pwsz.wloclawek.pl/images/Wykaz_dy%C5%BCur%C3%B3w_zz_w_sem._zim._2016-17.pdf");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            }
            if (Temp43 == "Zak³adu Informatyki")
            {
                var uri = Android.Net.Uri.Parse("https://www.pwsz.wloclawek.pl/images/Wykaz_dy%C5%BCur%C3%B3w_Inf._w_sem._zim._2016-17.pdf");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            }
            if (Temp43 == "Zak³adu Mechaniki i budowy maszyn")
            {
                var uri = Android.Net.Uri.Parse("https://www.pwsz.wloclawek.pl/images/Wykaz_dy%C5%BCur%C3%B3w_sem._zimowy_16-17_MiBM.pdf");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            }
            if (Temp43 == "Instytutu Nauk o Zdrowiu")
            {
                var uri = Android.Net.Uri.Parse("https://www.pwsz.wloclawek.pl/images/student/dyzury_2016-17_zima.pdf");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            }
            if (Temp43 == "Studium Wychowania Fizycznego i Sportu")
            {
                var uri = Android.Net.Uri.Parse("https://www.pwsz.wloclawek.pl/images/student/Dy%C5%BCury_semestr_2016-17_zima.pdf");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            }
            if (Temp43 == "Zak³adu Fiilologii Angielskiej, Pedagogiki, kierunku Nowe media i e-biznes oraz Studium Jêzyków Obcych")
            {
                var uri = Android.Net.Uri.Parse("https://www.pwsz.wloclawek.pl/images/Dy%C5%BCury_semestr_zima_16-17_17_listop.pdf");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            }


        }



    }
    }
