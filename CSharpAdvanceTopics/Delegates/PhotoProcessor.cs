using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.Delegates
{
    public class PhotoProcessor
    {
        public delegate void PhotoFilterHandler(Entities.Photo photo);
        public void ProcessWithoutDelegates(string path)
        {
            var photo = Entities.Photo.Load(path);

            var filters = new PhotoFilters();
            filters.ApplyBrightness(photo);
            filters.ApplyContrast(photo);
            filters.Resize(photo);

            photo.Save();
        }
        public void ProcessUsingCustomDelegates(string path, PhotoFilterHandler filterHandler)
        {
            var photo = Entities.Photo.Load(path);
            filterHandler(photo);

            photo.Save();
        }
        public void ProcessUsingNetDelegates(string path, Action<Entities.Photo> filterHandler)
        {
            var photo = Entities.Photo.Load(path);
            filterHandler(photo);

            photo.Save();
        }
    }
}
