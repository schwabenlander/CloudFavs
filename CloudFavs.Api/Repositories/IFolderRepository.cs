using CloudFavs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudFavs.Api.Repositories
{
    public interface IFolderRepository
    {
        Task<IEnumerable<Folder>> GetAllFolders(Guid ownerId);
        Task<Folder> GetFolderById(Guid folderId);
        Task<Folder> AddFolder(Folder folder);
        Task<Folder> UpdateFolder(Folder folder);
        Task DeleteFolder(Guid folderId);
    }
}
