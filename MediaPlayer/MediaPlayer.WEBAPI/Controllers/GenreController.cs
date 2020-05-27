using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.BLL.DTOs;
using MediaPlayer.BLL.Interfaces.IServices;
using MediaPlayer.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MediaPlayer.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> GetAll()
        {
            var genreDTOList = await genreService.GetAllGenresAsync();

            if (genreDTOList == null)
            {
                return NotFound();
            }

            return Ok(genreDTOList);
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> Get(int id)
        {
            var genreDTO = await genreService.GetGenreAsync(id);

            if (genreDTO == null)
            {
                return NotFound();
            }

            return Ok(genreDTO);
        }

        /// <summary>
        /// Create genre
        /// </summary>
        /// <param name="genreDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GenreDTO>> Post([FromBody]GenreDTO genreDTO)
        {
            if (genreDTO == null)
            {
                return BadRequest();
            }

            await genreService.AddGenreAsync(genreDTO);

            genreDTO = await genreService.GetGenreAsync(genreDTO.Name);

            return CreatedAtAction(nameof(Get), new { id = genreDTO.Id }, genreDTO);
        }

        /// <summary>
        /// Update by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genreDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<GenreDTO>> Put(int id, [FromBody]GenreDTO genreDTO)
        {
            if (genreDTO == null)
            {
                return BadRequest();
            }

            if (!await genreService.IsAnyGenreDefinedAsync(id))
            {
                return NotFound();
            }

            genreDTO.Id = id;

            await genreService.UpdateGenreAsync(genreDTO);

            return Ok(genreDTO);
        }

        /// <summary>
        /// Delete by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<GenreDTO>> Delete(int id)
        {
            

            if (!await genreService.IsAnyGenreDefinedAsync(id))
            {
                return NotFound();
            }

            await genreService.DeleteGenreAsync(id);

            return NoContent();
        }
    }
}
