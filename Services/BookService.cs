using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookReviewApp.Data;
using BookReviewApp.Dtos.BookDtos;
using BookReviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviewApp.Services;

public class BookService : IBookService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BookService (AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookResponseDto>> GetAllAsync()
    {
        return await _context.Books
            .ProjectTo<BookResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<BookResponseDto?> GetAsync(Guid id)
    {
        return await _context.Books
        .Where(b => b.Id == id)
        .ProjectTo<BookResponseDto>(_mapper.ConfigurationProvider)
        .FirstOrDefaultAsync();
    }

    public async Task<BookResponseDto> CreateAsync(BookCreateDto dto)
    {
        var book = _mapper.Map<Book>(dto);
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();

        return _mapper.Map<BookResponseDto>(book);
    }

    public async Task<BookResponseDto?> UpdateAsync (Guid id, BookUpdateDto dto)
    {
        var book = await _context.Books.FindAsync(id);
        if(book == null)
            return null;
        
        _mapper.Map(dto, book);
        await _context.SaveChangesAsync();

        return _mapper.Map<BookResponseDto>(book);
    }

    public async Task DeleteAsync(Guid id)
    {
        var book = await _context.Books.FindAsync(id);
        if(book == null)
            throw new KeyNotFoundException($"Book with Id {id} not found.");

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }


}
