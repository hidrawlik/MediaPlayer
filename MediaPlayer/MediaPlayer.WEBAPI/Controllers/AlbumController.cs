using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.BLL.DTOs;
using MediaPlayer.BLL.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MediaPlayer.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService albumService;

        public AlbumController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumDTO>>> GetAll()
        {
            var albumDTOList = await albumService.GetAllAlbumsAsync();

            if (albumDTOList == null)
            {
                return NotFound();
            }

            return Ok(albumDTOList);
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<AlbumDTO>> Get(int Id)
        {
            var albumDTO = await albumService.GetAlbumAsync(Id);

            if (albumDTO == null)
            {
                return NotFound();
            }

            return albumDTO;
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Delete by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<ActionResult<AlbumDTO>> Delete(int Id)
        {
            var albumDTO = await albumService.GetAlbumAsync(Id);

            if(albumDTO == null)
            {
                return NotFound();
            }

            await albumService.DeleteAlbumAsync(albumDTO);
            return NoContent();
        }
    }
}
