using CloudFavs.Shared;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Folder> AddFolder(Folder folder)
        {
            folder.Created = DateTime.Now;
            folder.LastModified = DateTime.Now;

            var newFolder = _dbContext.Add(folder);
            await _dbContext.SaveChangesAsync();

            return newFolder.Entity;
        }

        public async Task DeleteFolder(Guid folderId)
        {
            var folder = await _dbContext.Folders.FindAsync(folderId);

            // delete all favorites in the folder
            var favorites = await _dbContext.Favorites.Where(f => f.FolderId == folder.Id).ToListAsync();
            _dbContext.Favorites.RemoveRange(favorites);

            _dbContext.Folders.Remove(folder);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Folder> GetAllFolders(Guid ownerId)
        {
            return  _dbContext.Folders.Where(f => f.OwnerId == ownerId);
        }

        public async Task<Folder> GetFolderById(Guid folderId)
        {
            return await _dbContext.Folders.FindAsync(folderId);
        }

        public async Task<Folder> UpdateFolder(Folder folder)
        {
            var folderToUpdate = await _dbContext.Folders.FindAsync(folder.Id);

            folderToUpdate.LastModified = DateTime.Now;

            var updatedFolder = _dbContext.Folders.Update(folderToUpdate);
            await _dbContext.SaveChangesAsync();

            return updatedFolder.Entity;
        }
    }
}
