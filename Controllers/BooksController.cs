using AutoMapper;
using BooksAPI.DTOs;
using BooksAPI.Entitites;
using BooksAPI.Filters;
using BooksAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography.Xml;

namespace BooksAPI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController:ControllerBase
    {
        private readonly ILogger<BooksController> logger;
        private readonly AppDBContext context;
        private readonly IMapper mapper;
        public BooksController(ILogger<BooksController> logger,
                               AppDBContext context,
                               IMapper mapper) { 
            this.logger = logger;
            this.context = context; 
            this.mapper = mapper;  
        } 

        [HttpGet]
        public async Task<ActionResult<HomeDTO>> Get()
        {
            var top = 6;

            var booksToshow = await context.book
                .OrderBy(x => 1)
                .Take(top)
                .ToListAsync();
                
            var homeDto = new HomeDTO();

            homeDto.books = mapper.Map<List<BookDTO>>(booksToshow);

            return homeDto;
        }
        [HttpGet("search")]
        public async Task<ActionResult<HomeDTO>> GetSearch()
        {
            var bookSearch = await context.book
                .OrderBy(x => 1)
                .Select( x => new BookDTO
                {
                   bookID= x.bookID,
                   title= x.title
                })
                .ToListAsync();
            var search = new HomeDTO();
            search.books = mapper.Map<List<BookDTO>>(bookSearch);

            return search;
        }

        [HttpGet("filter")]
        public async Task<ActionResult<HomeDTO>> Filter([FromQuery]string title)
        {
            var booksQuery =  context.book.AsQueryable();
            int top = 5;

            if(!string.IsNullOrEmpty(title))
            {
                booksQuery =  booksQuery.Where(x => x.title.Contains(title)).Take(top);
            }
            var search = new HomeDTO();
            var books = await booksQuery.OrderBy(x => x.title).ToListAsync();
            search.books = mapper.Map<List<BookDTO>>(books);

            return search;
        }








        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookDTO>> Get(int id)


        {
            var book = await context.book
                .Include(x => x.author)
                .Include(x => x.editorial)
                .Include(x => x.saga)
                .Include(x => x.genersBook).ThenInclude(x => x.Gener)
                .FirstOrDefaultAsync(x => x.bookID == id);

            if (book == null)
            {
                return NotFound();
            }
            
            var dto = mapper.Map<BookDTO>(book);

            return dto;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Book book)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult Put(Book book)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Delete(int id) {
            throw new NotImplementedException();
        }
    }
}
