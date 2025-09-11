using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.Events
{
    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            if (e.Video != null)
            {
                Console.WriteLine("MessageService: Sending a text message..." + e.Video.Title);
            }
            else
            {
                Console.WriteLine("MessageService: Video is null. Cannot send a text message.");
            }
        }
    }
}
