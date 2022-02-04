using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FilmesApi.Profiles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeContext filmeContext;
        private readonly IMapper _mapper;

        public FilmeController(FilmeContext filmeContext, IMapper mapper)
        {
            this.filmeContext = filmeContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            filmeContext.Filmes.Add(filme);
            filmeContext.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }


        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return filmeContext.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            Filme filme = filmeContext.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(filmeDto);
            }

            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int  id ,[FromBody] UpdateFilmeDto filmeNovoDto)
        {
            Filme filme = filmeContext.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            filme = _mapper.Map(filmeNovoDto, filme);

            filmeContext.Update(filme);
            filmeContext.SaveChanges();
            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult RemoveFilme(int id)
        {
            Filme filme = filmeContext.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            filmeContext.Remove(filme);
            filmeContext.SaveChanges();
            return NoContent();
        }
    }
}
