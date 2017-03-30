using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Acr.IO.Tests
{

    [TestFixture]
    public class FileTests
    {

        [Test]
        public async Task CopyProgressTest()
        {
            var fs = new FileSystemImpl();

            await fs.GetFile("").CopyToAsync("", true, x => { });
        }


        [Test]
        public async Task CopyProgressCancelTest()
        {
            var fs = new FileSystemImpl();
            using (var cancelSrc = new CancellationTokenSource())
            {
                Task.Delay(500).ContinueWith(x => cancelSrc.Cancel());
                //Task.Delay(600).ContinueWith(x => // FAIL)
                await fs.GetFile("").CopyToAsync("", true, null, cancelSrc.Token);

            }
        }
    }
}
