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

        [HttpPost]
        public async Task<ActionResult<MusicCUDTO>> Add([FromBody]MusicCUDTO musicDto)
        {
            if (musicDto == null)
            {
                return BadRequest();
            }


            await musicService.AddMusicAsync(musicDto);

            musicDto = await musicService.GetMusicForUpdateAsync(musicDto.Name, musicDto.Author, musicDto.Year);

            return CreatedAtAction(nameof(GetForUpdate), new { id = musicDto.Id }, musicDto);
        }

        [HttpPut]
        public async Task<ActionResult<MusicCUDTO>> Update([FromBody]MusicCUDTO musicDto)
        {
            if (musicDto == null)
            {
                return BadRequest();
            }

            if (!await musicService.IsAnyMusicDefinedAsync(musicDto.Id))
            {
                return NotFound();
            }

            await musicService.UpdateMusicAsync(musicDto);
            return Ok(musicDto);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<MusicViewDTO>> Delete(int Id)
        {
            MusicViewDTO musicDto = await musicService.GetMusicForViewAsync(Id);

            if (musicDto == null)
            {
                return NotFound();
            }

            await musicService.DeleteMusicAsync(musicDto);
            return NoContent();
        }
    }
}