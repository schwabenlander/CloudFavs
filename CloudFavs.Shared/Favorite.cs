using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFavs.Shared
{
    public class Favorite
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Folder Folder { get; set; }
        public Guid FolderId { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsPinned { get; set; }
    }
}
