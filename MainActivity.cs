using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Widget;
using Apptest.Core;
using System.Threading.Tasks;
using Google.Android.Material.TextField;
using System.Text;
using AndroidX.RecyclerView.Widget;
using MvvmCross.Platforms.Android.Views;
using Apptest.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace Apptest.Droid
{
    [MvxActivityPresentation]
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

        }

        //private async void OnInsertClicked(object sender, EventArgs e)
        //{
        //   var insert = new Stock { Symbol = this.text.Text };
        //   await DbPartage.DB.SaveItem(insert);
        //    this.text.Text = "";
        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
