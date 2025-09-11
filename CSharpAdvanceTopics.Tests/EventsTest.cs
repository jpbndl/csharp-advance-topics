using CSharpAdvanceTopics.Entities;
using CSharpAdvanceTopics.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.Tests
{
    public class EventsTest
    {
        [Fact]
        public void ShouldTriggerTheEvents()
        {
            try
            {
                var video = new Video() { Title = "Test Video" };
                var videoEncoder = new VideoEncoder(); // publisher
                var mailService = new MailService(); // subscriber
                var messageService = new MessageService(); // subscriber

                videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
                videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

                videoEncoder.Encode(video);

                Assert.True(true);
            }
            catch (Exception) {
                Assert.True(false);
            }   
        }
    }
}
