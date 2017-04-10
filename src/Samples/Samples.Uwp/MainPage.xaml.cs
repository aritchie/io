using System;
using Acr.IO;


namespace Samples.Uwp
{
    public sealed partial class MainPage : Xamarin.Forms.Platform.UWP.WindowsPage
    {
        public MainPage()
        {
            FileSystem.Current.AppData = new Directory("");
            //this.InitializeComponent();
            this.LoadApplication(new Samples.App());
        }
    }
}
