using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediaPlayer.BLL.Interfaces.IServices;
using MediaPlayer.BLL.DTOs.MusicDTO;
using MediaPlayer.DAL.Entities;

namespace MediaPlayer.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService musicService;

        public MusicController(IMusicService musicService)
        {
            this.musicService = musicService;
        }


        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicViewDTO>>> GetAll()
        {
            IEnumerable<MusicViewDTO> musicsDto = await musicService.GetAllMusicAsync();

            if (musicsDto == null)
            {
                return NotFound();
            }

            return Ok(musicsDto);
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("{Id}")]
        [HttpGet]
        public async Task<ActionResult<MusicViewDTO>> GetForView(int Id)
        {
            MusicViewDTO musicDto = await musicService.GetMusicForViewAsync(Id);

            if (musicDto == null)
            {
                return NotFound();
            }

            return Ok(musicDto);
        }


        /// <summary>
        /// Get for Update by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("update/{Id}")]
        [HttpGet]
        public async Task<ActionResult<MusicCUDTO>> GetForUpdate(int Id)
        {
            var musicDto = await musicService.GetMusicForUpdateAsync(Id);

            if (musicDto == null)
            {
                return NotFound();
            }

            return Ok(musicDto);
        }


        /// <summary>
        /// Add music
        /// </summary>
        /// <param name="musicDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MusicCUDTO>> Add([FromBody]MusicCUDTO musicDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await musicService.AddMusicAsync(musicDto);

            musicDto = await musicService.GetMusicForUpdateAsync(musicDto.Name, musicDto.Author, musicDto.Year);

            return CreatedAtAction(nameof(GetForUpdate), new { id = musicDto.Id }, musicDto);
        }

        /// <summary>
        /// Update music
        /// </summary>
        /// <param name="musicDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MusicCUDTO>> Update([FromBody]MusicCUDTO musicDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await musicService.IsAnyMusicDefinedAsync(musicDto.Id))
            {
                return NotFound();
            }

            await musicService.UpdateMusicAsync(musicDto);
            return Ok(musicDto);
        }


        /// <summary>
        /// Delete by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<ActionResult<MusicViewDTO>> Delete(int Id)
        {
             var musicDto = await musicService.GetMusicForViewAsync(Id);

            if (musicDto == null)
            {
                return NotFound();
            }

            await musicService.DeleteMusicAsync(musicDto);
            return NoContent();
        }
    }
}