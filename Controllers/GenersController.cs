using AutoMapper;
using BooksAPI.DTOs;
using BooksAPI.Entitites;
using BooksAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace BooksAPI.Controllers
{
    [Route("api/geners")]
    [ApiController]
    public class GenersController : ControllerBase
    {
        private readonly ILogger<GenersController> logger;
        private readonly AppDBContext context;
        private readonly IMapper mapper;

        public GenersController(ILogger<GenersController> logger,
                                AppDBContext context,
                                IMapper mapper)
        {
            this.mapper = mapper;   
            this.context = context;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenerDTO>>> Get()
        {
            logger.LogInformation("Getting all geners");
            var geners = await context.gener.ToListAsync();

            return mapper.Map<List<GenerDTO>>(geners);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenerDTO>> Get(int id) {
            var gener = await context.gener
                .Where(x => x.generID == id)
                .ToListAsync();

            if (gener == null) return NotFound();

            var genre = mapper.Map<GenerDTO>(gener);

            return genre;
        }
        [HttpPut]
        public ActionResult<Gener> Put(Gener entity)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public ActionResult<Gener> Delete(int id) { 
            throw new NotImplementedException(); 
        }
        
    }
}
