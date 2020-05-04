using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediaPlayer.BLL.Interfaces.IServices;
using MediaPlayer.BLL.DTO;

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
        public async Task<ActionResult<IEnumerable<MusicDTO>>> GetAll()
        {
            IEnumerable<MusicDTO> musicsDto = await musicService.GetAllMusic();

            if(musicsDto == null)
            {
                return NotFound();
            }

            return Ok(musicsDto);
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<ActionResult<MusicDTO>> Get(int Id)
        {
            MusicDTO musicDto = await musicService.GetMusic(Id);
            
            if(musicDto == null)
            {
                return NotFound();
            }

            return Ok(musicDto);
        }

        [HttpPost]
        public async Task<ActionResult<MusicDTO>> Add(MusicDTO musicDto)
        {
            if (musicDto == null)
            {
                return BadRequest();
            }
            await musicService.AddMusic(musicDto);
            return Ok(musicDto);
        }

        [HttpPut]
        public async Task<ActionResult<MusicDTO>> Update(MusicDTO musicDto)
        {
            if (musicDto == null)
            {
                return BadRequest();
            }
            
            if (musicService.GetMusic(musicDto.Id) == null)
            {
                return NotFound();
            }
            
            await musicService.UpdateMusic(musicDto);
            return Ok(musicDto);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<MusicDTO>> Delete(int Id)
        {
            MusicDTO musicDto = musicService.GetMusic(Id).Result;
            
            if(musicDto == null)
            {
                return NotFound();
            }

            await musicService.DeleteMusic(musicDto);
            return Ok(musicDto);
        }
    }
}