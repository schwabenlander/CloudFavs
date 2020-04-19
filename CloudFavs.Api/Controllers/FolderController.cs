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
            try
            { 
                return Ok(_folderRepository.GetAllFolders(ownerId).Select(f => FolderToDTO(f)).ToList());
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FolderDTO>> GetFolder(Guid id)
        {
            try
            { 
                return Ok(FolderToDTO(await _folderRepository.GetFolderById(id)));
            }
            catch
            {
                // TODO: Log exception
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<FolderDTO>> CreateFolder([FromBody] FolderDTO folderDto)
        {
            var folder = new Folder
            {
                OwnerId = folderDto.OwnerId,
                Name = folderDto.Name
            };

            try
            { 
                var newFolder = await _folderRepository.AddFolder(folder);
                return CreatedAtAction(nameof(GetFolder), new { id = newFolder.Id }, FolderToDTO(newFolder));
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFolder(Guid id, FolderDTO folderDto)
        {
            if (id != folderDto.Id)
            {
                return BadRequest();
            }

            try 
            { 
                var folder = await _folderRepository.GetFolderById(id);

                folder.Name = folderDto.Name;

                await _folderRepository.UpdateFolder(folder);
                
                return NoContent();
            }
            catch
            {
                // TODO: Log exception
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFolder(Guid id)
        {
            try
            {
                await _folderRepository.DeleteFolder(id);
                return NoContent();
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        private static FolderDTO FolderToDTO(Folder folder) =>
            new FolderDTO
            {
                Id = folder.Id,
                OwnerId = folder.OwnerId,
                Name = folder.Name,
                Created = folder.Created,
                LastUpdated = folder.LastUpdated
            };
    }
}