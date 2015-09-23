using System;


namespace Acr.IO {

    public class FileCopyProgress {
        public TimeSpan TimeRemaining { get; }
        public TimeSpan TimeSpent { get; }
        public int PercentComplete { get; }
        public long FileSize { get; }
        public long BytesCompleted { get; }
        // TODO: throughput per second


        public FileCopyProgress(long bytesCompleted, long fileSize, DateTime startUtc) {
            this.FileSize = fileSize;
            this.BytesCompleted = bytesCompleted;
            this.PercentComplete = Convert.ToInt32(bytesCompleted * 100.0 / fileSize);
            this.TimeSpent = DateTime.UtcNow.Subtract(startUtc);
        }
    }
}
