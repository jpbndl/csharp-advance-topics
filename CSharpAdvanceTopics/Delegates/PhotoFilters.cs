using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.Delegates
{
    public class PhotoFilters
    {
        public void ApplyBrightness(Entities.Photo photo)
        {
            Console.WriteLine("Applying brightness");
        }
        public void ApplyContrast(Entities.Photo photo)
        {
            Console.WriteLine("Applying contrast");
        }
        public void Resize(Entities.Photo photo)
        {
            Console.WriteLine("Resizing the photo");
        }
    }
}
