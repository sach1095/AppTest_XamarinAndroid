using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Apptest.Core;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apptest.Droid
{
    [Activity(
         Label = "Apptest.Droid"
        , MainLauncher = true
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity<Setup, Core.App>
    {
        public SplashScreen()
             : base(Resource.Layout.SplashScreen)
        {
        }
    }


}