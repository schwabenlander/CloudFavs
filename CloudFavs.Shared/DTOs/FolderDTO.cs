using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudFavs.Shared.DTOs
{
    public class FolderDTO
    {
        public Guid Id { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        public Guid? ParentFolderId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }
    }
}
