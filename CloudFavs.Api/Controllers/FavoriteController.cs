using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFavs.Api.Repositories;
using CloudFavs.Shared;
using CloudFavs.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudFavs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteController(IFavoriteRepository favoriteRepository)
        {
            this._favoriteRepository = favoriteRepository;
        }

        [HttpGet("all/{ownerId}")]
        public ActionResult<IEnumerable<FavoriteDTO>> GetAllFavorites(Guid ownerId)
        {
            try
            {
                return Ok(_favoriteRepository.GetAllFavorites(ownerId).Select(f => FavoriteToDTO(f)).ToList());
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        [HttpGet("folder/{folderId}")]
        public ActionResult<IEnumerable<FavoriteDTO>> GetAllFavoritesInFolder(Guid folderId)
        {
            try
            {
                return Ok(_favoriteRepository.GetAllFavoritesInFolder(folderId).Select(f => FavoriteToDTO(f)).ToList());
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteDTO>> GetFavorite(Guid id)
        {
            try
            {
                return Ok(FavoriteToDTO(await _favoriteRepository.GetFavoriteById(id)));
            }
            catch
            {
                // TODO: Log exception
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<FavoriteDTO>> CreateFavorite([FromBody] FavoriteDTO favoriteDto)
        {
            var favorite = new Favorite
            {
                OwnerId = favoriteDto.OwnerId,
                FolderId = favoriteDto.FolderId,
                Name = favoriteDto.Name,
                Uri = favoriteDto.Uri,
                IsPinned = favoriteDto.IsPinned
            };

            try
            {
                var newFavorite = await _favoriteRepository.AddFavorite(favorite);
                return CreatedAtAction(nameof(GetFavorite), new { id = newFavorite.Id }, FavoriteToDTO(newFavorite));
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFavorite(Guid id, FavoriteDTO favoriteDto)
        {
            if (id != favoriteDto.Id)
            {
                return BadRequest();
            }

            try
            {
                var favorite = await _favoriteRepository.GetFavoriteById(id);

                favorite.Name = favoriteDto.Name;
                favorite.Uri = favoriteDto.Uri;
                favorite.IsPinned = favoriteDto.IsPinned;
                favorite.FolderId = favoriteDto.FolderId;

                await _favoriteRepository.UpdateFavorite(favorite);

                return NoContent();
            }
            catch
            {
                // TODO: Log exception
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(Guid id)
        {
            try
            {
                await _favoriteRepository.DeleteFavorite(id);
                return NoContent();
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        private static FavoriteDTO FavoriteToDTO(Favorite favorite) =>
            new FavoriteDTO
            {
                Id = favorite.Id,
                OwnerId = favorite.OwnerId,
                FolderId = favorite.FolderId,
                Name = favorite.Name,
                Uri = favorite.Uri,
                IsPinned = favorite.IsPinned,
                Created = favorite.Created,
                LastModified = favorite.LastModified
            };
    }
}