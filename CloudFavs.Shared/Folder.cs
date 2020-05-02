using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CloudFavs.Shared
{
    public class Folder
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        public Folder ParentFolder { get; set; }

        public Guid? ParentFolderId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }
    }
}
