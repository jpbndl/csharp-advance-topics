using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.Tests
{
    public class DelegatesTest
    {
        [Fact]
        public void ShouldTestPhotoProcessingWithoutDelegates()
        {
            var photoProcessor = new CSharpAdvanceTopics.Delegates.PhotoProcessor();
            photoProcessor.ProcessWithoutDelegates("photo.jpg");

            Assert.True(true);
        }

        [Fact]
        public void ShouldTestPhotoProcessingUsingCustomDelegates()
        {
            var photoProcessor = new CSharpAdvanceTopics.Delegates.PhotoProcessor();
            var filters = new CSharpAdvanceTopics.Delegates.PhotoFilters();
            CSharpAdvanceTopics.Delegates.PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += filters.Resize;
            photoProcessor.ProcessUsingCustomDelegates("photo.jpg", filterHandler);

            Assert.True(true);
        }

        [Fact]
        public void ShouldTestPhotoProcessingUsingNetDelegates()
        {
            var photoProcessor = new CSharpAdvanceTopics.Delegates.PhotoProcessor();
            var filters = new CSharpAdvanceTopics.Delegates.PhotoFilters();
            Action<CSharpAdvanceTopics.Entities.Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += filters.Resize;
            photoProcessor.ProcessUsingNetDelegates("photo.jpg", filterHandler);

            Assert.True(true);
        }
    }
}
