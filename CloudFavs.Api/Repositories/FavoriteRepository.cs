using CloudFavs.Shared;
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
        public Favorite AddFavorite(Favorite favorite)
        {
            throw new NotImplementedException();
        }

        public void DeleteFavorite(Guid favoriteID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Favorite> GetAllFavorites(Guid ownerId)
        {
            throw new NotImplementedException();
        }

        public Favorite GetFavoriteById(Guid favoriteId)
        {
            throw new NotImplementedException();
        }

        public Favorite UpdateFavorite(Favorite favorite)
        {
            throw new NotImplementedException();
        }
    }
}
