using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arduino
{
    [Activity(Label = "ReferencesActivity")]
    public class ReferencesActivity : Activity
    {
        TextView textView1;
        TextView textView2;
        TextView textView3;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_references);

            textView1 = FindViewById<TextView>(Resource.Id.referenceText1);
            textView2 = FindViewById<TextView>(Resource.Id.referenceText2);
            textView3 = FindViewById<TextView>(Resource.Id.referenceText3);

            textView1.Click += TextView1_Click;
            textView2.Click += TextView2_Click;
            textView3.Click += TextView3_Click;

            textView1.Text = "https://tr.wikipedia.org/wiki/Arduino";
            textView2.Text = "https://maker.robotistan.com/kategori/arduino/arduino-projeleri/";
            textView3.Text = "http://www.netber.com/yeni-baslayanlar-icin-arduino-tavsiyeleri";
        }
        private void TextView1_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Intent.ActionView,Android.Net.Uri.Parse("https://tr.wikipedia.org/wiki/Arduino"));
            StartActivity(intent);
        }
        private void TextView2_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://maker.robotistan.com/kategori/arduino/arduino-projeleri/"));
            StartActivity(intent);
        }
        private void TextView3_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://www.netber.com/yeni-baslayanlar-icin-arduino-tavsiyeleri"));
            StartActivity(intent);
        }
    }
}