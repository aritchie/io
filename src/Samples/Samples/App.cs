using System;
using System.Reflection;
using Acr.IO;
using Xamarin.Forms;


namespace Samples
{

    public class App : Application
    {

        public App()
        {

            this.MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Button {
                            Text = "Open Test PDF",
                            Command = new Command(async () =>
                            {
                                var file = FileSystem.Current.Public.GetFile("temp.pdf");
                                file.DeleteIfExists();

                                var assembly = Assembly.Load(new AssemblyName("Samples"));
                                using (var stream = assembly.GetManifestResourceStream("test.pdf"))
                                    using (var fs = file.OpenWrite())
                                        stream.CopyTo(fs);

                                if (!FileViewer.Current.Open(file))
                                    await this.MainPage.DisplayAlert("ERROR", "Could not open file " + file.FullName, "OK");
                            })
                        },
                        new Label
                        {
                            Text = "App Data: " + FileSystem.Current.AppData.FullName
                        },
                        new Label
                        {
                            Text = "Cache Data: " + FileSystem.Current.Cache.FullName
                        },
                        new Label
                        {
                            Text = "Public: " + FileSystem.Current.Public.FullName
                        },
                        new Label
                        {
                            Text = "Temp: " + FileSystem.Current.Temp.FullName
                        }
                    }
                }
            };
        }
    }
}
