﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudFavs.Shared.DTOs
{
    public class FavoriteDTO
    {
        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }

        public Guid FolderId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Uri { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

        public bool IsPinned { get; set; }
    }
}