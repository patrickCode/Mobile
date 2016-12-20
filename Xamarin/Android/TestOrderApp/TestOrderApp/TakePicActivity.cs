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
using Java.IO;
using Android.Provider;
using Android.Graphics;
using TestOrderApp.Utility;

namespace TestOrderApp
{
    [Activity(Label = "Take a Photo", MainLauncher = false)]
    public class TakePicActivity : Activity
    {
        private ImageView _cameraImageView;
        private Button _launchCameraButtonView;
        private File _imageDirectory; //Using Java.IO
        private File _imageFile;
        private Bitmap _imageBitmap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TakePicLayout);

            FindViews();
            HandleEvents();

            //Create a sub-folder in the directory where Android images are stored
            //For this operation WRITE_EXTERNAL_STORAGE permission must be set in the manifest
            _imageDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "MyApp_Pics");
            if (!_imageDirectory.Exists())
            {
                _imageDirectory.Mkdirs();
            }
        }

        private void FindViews()
        {
            _cameraImageView = FindViewById<ImageView>(Resource.Id.camImageView);
            _launchCameraButtonView = FindViewById<Button>(Resource.Id.launchCamButtonView);
        }

        private void HandleEvents()
        {
            _launchCameraButtonView.Click += _launchCameraButtonView_Click;
        }

        private void _launchCameraButtonView_Click(object sender, EventArgs e)
        {
            //ActionImageCapture is the action which allows the app to take an image from the camera and return it to the app
            var intent = new Intent(MediaStore.ActionImageCapture);
            _imageFile = new File(_imageDirectory, $"App_Phtoto_{Guid.NewGuid().ToString()}.jpeg");
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_imageFile)); //This is where the image will be stored

            StartActivityForResult(intent, 0); //A result is expected inside the activity when the photo has been taken
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (requestCode == 0)
            {
                int height = _cameraImageView.Height;
                int width = _cameraImageView.Width;
                _imageBitmap = ImageHelper.GetImageFromFilePath(_imageFile.Path, width, height);

                if (_imageBitmap != null)
                {
                    _cameraImageView.SetImageBitmap(_imageBitmap);
                    _imageBitmap = null;
                }
            }

            //To avoid memory leak
            GC.Collect();
        }
    }
}