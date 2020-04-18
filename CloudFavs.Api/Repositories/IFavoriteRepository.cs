using CloudFavs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudFavs.Api.Repositories
{
    public interface IFavoriteRepository
    {
        IEnumerable<Favorite> GetAllFavorites(Guid ownerId);
        Favorite GetFavoriteById(Guid favoriteId);
        Favorite AddFavorite(Favorite favorite);
        Favorite UpdateFavorite(Favorite favorite);
        void DeleteFavorite(Guid favoriteID);
    }
}
