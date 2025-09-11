using CSharpAdvanceTopics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.Events
{
    public class VideoEncoder
    {
        // 1. Define a delegate
        // 2. Define an event based on that delegate
        // 3. Raise the event - we need method resposible to that
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
        public event VideoEncodedEventHandler? VideoEncoded;

        // In .NET , there is a built-in generic delegate EventHandler<T> that can be used instead of defining our own delegate.
        // EventHandler
        // EventHandler<TEventArgs>
        // public event EventHandler<VideoEventArgs> VideoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        // By convention, the method that raises the event is protected and virtual and should start with "On"
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
            {
                VideoEncoded(this, new VideoEventArgs() { Video = video });
            }
        }

        public void EncodeWithoutEvent(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);
        }
    }
}
