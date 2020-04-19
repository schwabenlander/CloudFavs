using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFavs.Shared
{
    public class Folder
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
