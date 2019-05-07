using System;
using System.Collections.Generic;
using Business;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class GenreController : Controller
    {

        private readonly GenreManager _genreManager;

        public GenreController(IConfiguration config)
        {
            _genreManager = new GenreManager(config);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Genre> Get()
        {
            return _genreManager.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Genre Get(string id)
        {
            return _genreManager.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public Genre Post([FromBody]Genre genre)
        {
            return _genreManager.Create(genre);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody]Genre genre)
        {
            genre.Id = id;
            _genreManager.Update(genre);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            _genreManager.Delete(id);
        }
    }
}
