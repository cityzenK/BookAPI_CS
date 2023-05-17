using AutoMapper;
using BooksAPI.DTOs;
using BooksAPI.Entitites;

namespace BooksAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GenerDTO, Gener>().ReverseMap();
            CreateMap<authorDTO, Author>().ReverseMap();
            CreateMap<HomeBookDTO, HomeBook>().ReverseMap();    
            CreateMap<SagaDTO, Saga>().ReverseMap();
            CreateMap<authorDTO, Author>().ReverseMap();
            CreateMap<Editorial, EditorialDTO>().ReverseMap();
            CreateMap<BookDTO, Book>().ReverseMap()
                .ForMember(x => x.genersBook, options => options.MapFrom(MapBookGeners));
        }
        
        private List<GenerDTO> MapBookGeners(Book book, BookDTO bookdto)
        {
            var result = new List<GenerDTO>();

            if (book.genersBook != null)
            {
                foreach (var geners in book.genersBook)
                {
                    result.Add(new GenerDTO() { generID = geners.generID, gener = geners.Gener.gener });
                }
            }
            return result;


        }



    }
}
