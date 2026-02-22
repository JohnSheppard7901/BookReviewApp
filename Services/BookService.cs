using AutoMapper;
using BookReviewApp.Data;
using BookReviewApp.Dtos.BookDtos;

namespace BookReviewApp.Services;

public class BookService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BookService (AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // public async Task<IEnumerable<BookResponseDto>> GetAllAsync()
    // {
    //     return responseDtoList;
    // }

    // public async Task<BookResponseDto> GetAsync(Guid id)
    // {
    //     return responseDto;
    // }

    // public async Task<BookResponseDto> CreateAsync(BookCreateDto dto)
    // {
    //     return responseDto;
    // }

    // public async Task<BookResponseDto> UpdateAsync (Guid id, BookUpdateDto dto)
    // {
    //     return responseDto;
    // }

    public async Task DeleteAsync(Guid id)
    {
        
    }


}
