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
        IEnumerable<Favorite> GetPinnedFavorites(Guid ownerId);
        Task<Favorite> GetFavoriteById(Guid favoriteId);
        Task<Favorite> AddFavorite(Favorite favorite);
        Task<Favorite> UpdateFavorite(Favorite favorite);
        Task DeleteFavorite(Guid favoriteID);
    }
}
