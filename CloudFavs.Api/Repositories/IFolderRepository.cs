using CloudFavs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudFavs.Api.Repositories
{
    public interface IFolderRepository
    {
        IEnumerable<Folder> GetAllFolders(Guid ownerId);
        Folder GetFolderById(Guid folderId);
        Folder AddFolder(Folder folder);
        Folder UpdateFolder(Folder folder);
        void DeleteFolder(Guid folderId);
    }
}
