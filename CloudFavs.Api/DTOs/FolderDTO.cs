using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudFavs.Api.DTOs
{
    public class FolderDTO
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
