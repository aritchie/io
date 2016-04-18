using System;
using Acr.Support.iOS;
using UIKit;


namespace Acr.IO
{

    public class FileViewerInterationDelegate : UIDocumentInteractionControllerDelegate
    {
        private readonly UIViewController controller;
        private readonly UIView view;


        public FileViewerInterationDelegate()
        {
            this.controller = UIApplication.SharedApplication.GetTopViewController();
            this.view = UIApplication.SharedApplication.GetTopView();


            //var publicData = NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.SharedPublicDirectory, NSSearchPathDomain.User)[0].Path;
            //var appData = NSFileManager.DefaultManager.GetUrls (NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User)[0].Path;
            //var cache = NSFileManager.DefaultManager.GetUrls (NSSearchPathDirectory.CachesDirectory, NSSearchPathDomain.User)[0].Path;
            //var temp = NSFileManager.DefaultManager.GetUrls (NSSearchPathDirectory.CachesDirectory, NSSearchPathDomain.User)[0].Path;


            //var documents = UIDevice.CurrentDevice.CheckSystemVersion(8, 0)
            //    ? NSFileManager.DefaultManager.GetUrls (NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User)[0].Path
            //    : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //var library = Path.Combine(documents, "..", "Library");
            //this.AppData = new Directory(library);
            //this.Cache = new Directory(Path.Combine(library, "Caches"));
            //this.Temp = new Directory(Path.Combine(documents, "..", "tmp"));
            //this.Public = new Directory(documents);
        }


        public override UIViewController ViewControllerForPreview(UIDocumentInteractionController controller)
        {
            return this.controller;
        }


        public override UIView ViewForPreview(UIDocumentInteractionController controller)
        {
            return this.view;
        }
    }
}