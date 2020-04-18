using CloudFavs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudFavs.Api.Repositories
{
    public class FolderRepository : IFolderRepository
    {
        private readonly AppDbContext _dbContext;

        public FolderRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Folder AddFolder(Folder folder)
        {
            var newFolder = _dbContext.Add(folder);
            _dbContext.SaveChanges();

            return newFolder.Entity;
        }

        public void DeleteFolder(Guid folderId)
        {
            var folder = _dbContext.Folders.SingleOrDefault(f => f.Id == folderId);
            if (folder == null) return;

            _dbContext.Folders.Remove(folder);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Folder> GetAllFolders(Guid ownerId)
        {
            return _dbContext.Folders.Where(f => f.Owner == ownerId);
        }

        public Folder GetFolderById(Guid folderId)
        {
            return _dbContext.Folders.SingleOrDefault(f => f.Id == folderId);
        }

        public Folder UpdateFolder(Folder folder)
        {
            var folderToUpdate = _dbContext.Folders.SingleOrDefault(f => f.Id == folder.Id);
            if (folderToUpdate == null) return null;
            
            var updatedFolder = _dbContext.Folders.Update(folder);
            _dbContext.SaveChanges();

            return updatedFolder.Entity;
        }
    }
}
