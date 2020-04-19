using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudFavs.Api.DTOs
{
    public class FavoriteDTO
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Guid FolderId { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsPinned { get; set; }
    }
}
