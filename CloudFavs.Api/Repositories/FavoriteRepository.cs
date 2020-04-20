using CloudFavs.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudFavs.Api.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _dbContext;

        public FavoriteRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Favorite> AddFavorite(Favorite favorite)
        {
            // ensure underlying folder exists
            if (!(await _dbContext.Folders.AnyAsync(f => f.Id == favorite.FolderId)))
                throw new Exception($"Folder ({favorite.FolderId}) does not exist.");

            favorite.Created = DateTime.Now;
            favorite.LastModified = DateTime.Now;

            var newFavorite = _dbContext.Favorites.Add(favorite);
            await _dbContext.SaveChangesAsync();
            
            return newFavorite.Entity;
        }

        public async Task DeleteFavorite(Guid favoriteID)
        {
            var favorite = await _dbContext.Favorites.FindAsync(favoriteID);
            if (favorite == null) return;

            _dbContext.Favorites.Remove(favorite);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Favorite> GetAllFavorites(Guid ownerId)
        {
            return _dbContext.Favorites.Where(f => f.OwnerId == ownerId);
        }

        public async Task<Favorite> GetFavoriteById(Guid favoriteId)
        {
            return await _dbContext.Favorites.FindAsync(favoriteId);
        }

        public IEnumerable<Favorite> GetAllFavoritesInFolder(Guid folderId)
        {
            return _dbContext.Favorites.Where(f => f.FolderId == folderId);
        }

        public async Task<Favorite> UpdateFavorite(Favorite favorite)
        {
            var favoriteToUpdate = await _dbContext.Favorites.FindAsync(favorite.Id);
            if (favoriteToUpdate == null) return null;

            favorite.LastModified = DateTime.Now;
            var updatedFavorite =  _dbContext.Favorites.Update(favorite);
            await _dbContext.SaveChangesAsync();

            return updatedFavorite.Entity;
        }
    }
}
