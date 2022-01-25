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
    [Activity(Label = "ImageActivity")]
    public class ImageActivity : Activity
    {
        ImageView imageView;
        String image;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_image);

            imageView = FindViewById<ImageView>(Resource.Id.arduinoImageView);

            image = Intent.GetStringExtra("image");
            showImage(image);
        }
        private void showImage(string image)
        {
            if (image == "model")
            {
                imageView?.SetImageResource(Resource.Drawable.arduino_modeller);
            }
            else if (image == "uno")
            {
                imageView?.SetImageResource(Resource.Drawable.arduino_uno_r3_orijinal);
            }else if(image == "mega")
            {
                imageView?.SetImageResource(Resource.Drawable.arduino_mega_2560_r3);
            }else if(image == "mini")
            {
                imageView?.SetImageResource(Resource.Drawable.arduino_pro_mini);
            }
            else if (image == "nano")
            {
                imageView?.SetImageResource(Resource.Drawable.arduino_nano1);
            }
            else if (image == "zero")
            {
                imageView?.SetImageResource(Resource.Drawable.arduino_zero);
            }
            else if (image == "gemma")
            {
                imageView?.SetImageResource(Resource.Drawable.arduino_gemma);
            }
            else if (image == "lilypad")
            {
                imageView?.SetImageResource(Resource.Drawable.arduino_lilypad);
            }
            else if (image == "yun")
            {
                imageView?.SetImageResource(Resource.Drawable.arduino_yun);
            }
        }
    }
}