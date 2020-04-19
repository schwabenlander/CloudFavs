using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFavs.Api.DTOs;
using CloudFavs.Api.Repositories;
using CloudFavs.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudFavs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IFolderRepository _folderRepository;

        public FolderController(IFolderRepository folderRepository)
        {
            this._folderRepository = folderRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Folder>> GetAllFolders(Guid ownerId)
        {
            return Ok(_folderRepository.GetAllFolders(ownerId).Select(f => FolderToDTO(f)).ToList());
        }

        private static FolderDTO FolderToDTO(Folder folder) =>
            new FolderDTO
            {
                Id = folder.Id,
                OwnerId = folder.OwnerId,
                Name = folder.Name
            };
    }
}