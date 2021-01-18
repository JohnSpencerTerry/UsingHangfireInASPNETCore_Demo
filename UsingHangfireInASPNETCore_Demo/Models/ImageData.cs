using System.Collections.Generic;

namespace UsingHangfireInASPNETCore_Demo.Models
{
    public class ImageData
    {
        public string DisplayName { get; set; }
        public string Container { get; set; }
        public string FileName { get; set; }
        public string ImageType { get; set; }
        public List<ImageData> Variants { get;  set; }
    }
}