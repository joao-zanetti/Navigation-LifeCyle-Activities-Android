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
using Navigater.core;

namespace Navigater
{
    [Activity(Label = "RecvActivity")]
    public class RecvActivity : Activity
    {
        TextView textView1;
        TextView textView2;
        TextView globalsText2;
        Button buttonBack;
        Button buttonAdd2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.recvactivity);

            textView1 = FindViewById<TextView>(Resource.Id.textView1);
            textView2 = FindViewById<TextView>(Resource.Id.textView2);
            buttonBack = FindViewById<Button>(Resource.Id.buttonBack);
            buttonAdd2 = FindViewById<Button>(Resource.Id.buttonAdd2);
            globalsText2 = FindViewById<TextView>(Resource.Id.globalsText2);

            string text1 = Intent.GetStringExtra("name" ?? "Not rec");
            string text2 = Intent.GetStringExtra("email" ?? "Not rec");

            textView1.Text = text1;
            textView2.Text = text2;

            buttonBack.Click += delegate
            {
                this.Finish();
            };

            buttonAdd2.Click += delegate
            {
                Globals.AddNewStatus(1);
                string resposta = "nelemens" + Globals.StatusApplication.Count.ToString();
                resposta += "element" + Globals.StatusApplication[Globals.StatusApplication.Count - 1].ToString();
                globalsText2.Text = resposta;
            };

        }

        protected override void OnStart()
        {
            base.OnStart();
            string resposta = "nelemens" + Globals.StatusApplication.Count.ToString();
            if (Globals.StatusApplication.Count > 0)
            {
                resposta += "element" + Globals.StatusApplication[Globals.StatusApplication.Count - 1].ToString();
            }
            globalsText2.Text = resposta;

        }
        protected override void OnStop()
        {
            base.OnStop();

            Toast.MakeText(this, "ONSTOP RECV", ToastLength.Short).Show();
        }

        protected override void OnPause()
        {
            base.OnPause();

            Toast.MakeText(this, "ONPAUSE RECV", ToastLength.Short).Show();
        }

        protected override void OnRestart()
        {
            base.OnRestart();

            Toast.MakeText(this, "ONRESTART RECV", ToastLength.Short).Show();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();

            Toast.MakeText(this, "ONDESTROY RECV", ToastLength.Short).Show();
        }
    }
}