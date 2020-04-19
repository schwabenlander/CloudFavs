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

        [HttpGet("all/{ownerId}")]
        public ActionResult<IEnumerable<FolderDTO>> GetAllFolders(Guid ownerId)
        {
            return Ok(_folderRepository.GetAllFolders(ownerId).Select(f => FolderToDTO(f)).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FolderDTO>> GetFolder(Guid id)
        {
            return Ok(FolderToDTO(await _folderRepository.GetFolderById(id)));
        }

        [HttpPost]
        public async Task<ActionResult<FolderDTO>> CreateFolder([FromBody] FolderDTO folderDto)
        {
            var folder = new Folder
            {
                OwnerId = folderDto.OwnerId,
                Name = folderDto.Name
            };

            var newFolder = await _folderRepository.AddFolder(folder);

            return CreatedAtAction(nameof(GetFolder), new { id = newFolder.Id }, newFolder);
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