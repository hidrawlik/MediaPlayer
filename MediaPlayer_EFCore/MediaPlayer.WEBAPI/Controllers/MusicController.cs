using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediaPlayer.BLL.Interfaces;
using MediaPlayer.DAL;

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
        public async Task<ActionResult<IEnumerable<Music>>> GetAll()
        {
            IEnumerable<Music> musics = await musicService.GetAll();

            if(musics == null)
            {
                return NotFound();
            }

            return Ok(musics);
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<ActionResult<Music>> Get(int Id)
        {
            Music music = await musicService.Get(Id);
            
            if(music == null)
            {
                return NotFound();
            }

            return Ok(music);
        }

        [HttpPost]
        public async Task<ActionResult<Music>> Add(Music music)
        {
            if (music == null)
            {
                return BadRequest();
            }
            await musicService.Add(music);
            return Ok(music);
        }

        [HttpPut]
        public async Task<ActionResult<Music>> Update(Music music)
        {
            if (music == null)
            {
                return BadRequest();
            }
            
            if (musicService.Get(music.Id) == null)
            {
                return NotFound();
            }
            
            await musicService.Update(music);
            return Ok(music);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Music>> Delete(int Id)
        {
            Music music = musicService.Get(Id).Result;
            
            if(music == null)
            {
                return NotFound();
            }

            await musicService.Delete(music);
            return Ok(music);
        }
    }
}