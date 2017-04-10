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

            var fs = FileSystem.Current;

            this.MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Button
                        {
                            Text = "Open Test PDF",
                            Command = new Command(async () =>
                            {
                                var file = fs.Public.GetFile("temp.pdf");
                                file.DeleteIfExists();

                                var assembly = Assembly.Load(new AssemblyName("Samples"));
                                using (var stream = assembly.GetManifestResourceStream("test.pdf"))
                                    using (var fileStream = file.OpenWrite())
                                        stream.CopyTo(fileStream);

                                if (!FileViewer.Current.Open(file))
                                    await this.MainPage.DisplayAlert("ERROR", "Could not open file " + file.FullName, "OK");
                            })
                        },
                        new Label
                        {
                            Text = "App Data: " + fs.AppData.FullName
                        },
                        new Label
                        {
                            Text = "Cache Data: " + fs.Cache.FullName
                        },
                        new Label
                        {
                            Text = "Public: " + fs.Public.FullName
                        },
                        new Label
                        {
                            Text = "Temp: " + fs.Temp.FullName
                        }
                    }
                }
            };
        }
    }
}
