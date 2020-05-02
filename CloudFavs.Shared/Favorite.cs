using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CloudFavs.Shared
{
    public class Favorite
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        public Folder Folder { get; set; }

        public Guid FolderId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Uri { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

        public bool IsPinned { get; set; }
    }
}
