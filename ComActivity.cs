using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Navigater
{
    [Activity(Label = "Activity1")]
    public class ComActivity : Activity
    {
        Button buttonBack3;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.comactivity);

            buttonBack3 = FindViewById<Button>(Resource.Id.buttonBack3);

            buttonBack3.Click += delegate
             {
                 Intent nextActivity = new Intent(this, typeof(MainActivity));
                 StartActivity(nextActivity);
             };

        }

        protected override void OnStart()
        {
            base.OnStart();

            Toast.MakeText(this, "ONSTART COM", ToastLength.Short).Show();
        }


        protected override void OnStop()
        {
            base.OnStop();

            Toast.MakeText(this, "ONSTOP COM", ToastLength.Short).Show();
        }

        protected override void OnPause()
        {
            base.OnPause();

            Toast.MakeText(this, "ONPAUSE COM", ToastLength.Short).Show();
        }

        protected override void OnRestart()
        {
            base.OnRestart();

            Toast.MakeText(this, "ONRESTART COM", ToastLength.Short).Show();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();

            Toast.MakeText(this, "ONDESTROY COM", ToastLength.Short).Show();
        }
    }
}