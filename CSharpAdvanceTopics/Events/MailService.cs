using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.Events
{
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            if (e.Video != null)
            {
                Console.WriteLine("MailService: Sending an email..." + e.Video.Title);
            }
            else
            {
                Console.WriteLine("MailService: Video is null. Cannot send email.");
            }
        }
    }
}
