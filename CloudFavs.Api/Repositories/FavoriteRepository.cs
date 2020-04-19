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

        public IEnumerable<Favorite> GetPinnedFavorites(Guid ownerId)
        {
            return _dbContext.Favorites.Where(f => f.OwnerId == ownerId && f.IsPinned);
        }

        public async Task<Favorite> UpdateFavorite(Favorite favorite)
        {
            var favoriteToUpdate = await _dbContext.Favorites.FindAsync(favorite.Id);
            if (favoriteToUpdate == null) return null;

            var updatedFavorite =  _dbContext.Favorites.Update(favorite);
            await _dbContext.SaveChangesAsync();

            return updatedFavorite.Entity;
        }
    }
}
