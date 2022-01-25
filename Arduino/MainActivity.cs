using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Content;
using Android.Preferences;

namespace Arduino
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView text;
        Button button1;
        Button button2;
        Button button3;
        Button button4;
        Button button5;
        Button button6;
        Button button7;
        Button button8;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
            SetContentView(Resource.Layout.activity_main);

            text = FindViewById<TextView>(Resource.Id.textView);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            button3 = FindViewById<Button>(Resource.Id.button3);
            button4 = FindViewById<Button>(Resource.Id.button4);
            button5 = FindViewById<Button>(Resource.Id.button5);
            button6 = FindViewById<Button>(Resource.Id.button6);
            button7 = FindViewById<Button>(Resource.Id.button7);
            button8 = FindViewById<Button>(Resource.Id.button8);

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;
            button5.Click += Button5_Click;
            button6.Click += Button6_Click;
            button7.Click += Button7_Click;
            button8.Click += Button8_Click;
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(DetailsActivity));
            intent.PutExtra("button", "button1");
            StartActivity(intent);
        }
        private void Button2_Click(object sender, System.EventArgs e)
        {
           var intent = new Intent(this, typeof(DetailsActivity));
            intent.PutExtra("button", "button2");
            StartActivity(intent);
        }
        private void Button3_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(DetailsActivity));
            intent.PutExtra("button", "button3");
            StartActivity(intent);
        }
        private void Button4_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(DetailsActivity));
            intent.PutExtra("button", "button4");
            StartActivity(intent);
        }
        private void Button5_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(DetailsActivity));
            intent.PutExtra("button", "button5");
            StartActivity(intent);
        }
        private void Button6_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(DetailsActivity));
            intent.PutExtra("button", "button6");
            StartActivity(intent);
        }
        private void Button7_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(DetailsActivity));
            intent.PutExtra("button", "button7");
            StartActivity(intent);
        }
        private void Button8_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof (ReferencesActivity));
            StartActivity(intent);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}