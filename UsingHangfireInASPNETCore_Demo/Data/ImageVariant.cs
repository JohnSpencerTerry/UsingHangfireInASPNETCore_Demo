using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingHangfireInASPNETCore_Demo.Data
{
    public class ImageVariant
    {
        public int Id { get; set; }

        public int OrginalImageId { get; set; }

        public string VariantDescription { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ContainerOrDirectory { get; set; }

        public string FileName { get; set; }
        public string MD5Hash { get; set; }
    }
}
