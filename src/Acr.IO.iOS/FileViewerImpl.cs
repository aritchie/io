using System;
using Foundation;
using UIKit;


namespace Acr.IO {

	public class FileViewerImpl : IFileViewer {

		public bool Open(IFile file) {
			var opened = false;
            new System.IO.FileSystemWatcher();

            var url = NSUrl.FromFilename(file.FullName);
			if (url.IsFileUrl) {
				using (var controller = UIDocumentInteractionController.FromUrl(url)) {
					UIApplication.SharedApplication.InvokeOnMainThread(() => {
						controller.Delegate = new FileViewerInterationDelegate();
						opened = controller.PresentPreview(true);
					});
				}
			}
			return opened;
		}
	}
}