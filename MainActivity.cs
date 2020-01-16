using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Navigater.core;
using Android.Util;

namespace Navigater
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        EditText editText1;
        EditText editText2;
        TextView globalsText1;
        Button buttonGo;
        Button buttonGo2;
        Button buttonAdd1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            editText1 = FindViewById<EditText>(Resource.Id.editText1);
            editText2 = FindViewById<EditText>(Resource.Id.editText2);
            buttonAdd1 = FindViewById<Button>(Resource.Id.buttonAdd1);
            globalsText1 = FindViewById<TextView>(Resource.Id.globalsText1);
            buttonGo = FindViewById<Button>(Resource.Id.buttonGo);
            buttonGo2 = FindViewById<Button>(Resource.Id.buttonGo2);


            buttonGo.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(RecvActivity));
                nextActivity.PutExtra("name", editText1.Text);
                nextActivity.PutExtra("email", editText2.Text);
                StartActivity(nextActivity);
            };

            buttonGo2.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(ComActivity));
                StartActivity(nextActivity);
            };

            buttonAdd1.Click += delegate
            {
                Globals.AddNewStatus(0);
                string resposta = "nelemens" + Globals.StatusApplication.Count.ToString();
                resposta += "element" + Globals.StatusApplication[Globals.StatusApplication.Count - 1].ToString();
                globalsText1.Text = resposta;
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnStart()
        {
            base.OnStart();
            string resposta = "nelemens" + Globals.StatusApplication.Count.ToString();
            if (Globals.StatusApplication.Count>0)
            {
                resposta += "element" + Globals.StatusApplication[Globals.StatusApplication.Count - 1].ToString();
            }
            globalsText1.Text = resposta;

        }

        protected override void OnStop()
        {
            base.OnStop();

           Toast.MakeText(this, "ONSTOP MAIN", ToastLength.Short).Show();
        }

        protected override void OnPause()
        {
            base.OnPause();

            Toast.MakeText(this, "ONPAUSE MAIN", ToastLength.Short).Show();
        }

        protected override void OnRestart()
        {
            base.OnRestart();

            Toast.MakeText(this, "ONRESTART MAIN", ToastLength.Short).Show();
        }
    }
}