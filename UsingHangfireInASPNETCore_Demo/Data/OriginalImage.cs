using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingHangfireInASPNETCore_Demo.Data
{
    public class OriginalImage
    {
        public int Id { get; set; }

        public string AspNetUserID { get; set; }

        public string DisplayName { get; set; }

        public string MD5Hash { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ContainerOrDirectory { get; set; }

        public string FileName { get; set; }

        public ICollection<ImageVariant> ImageVariants { get; set; }
    }
}
