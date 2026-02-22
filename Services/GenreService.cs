using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookReviewApp.Data;
using BookReviewApp.Dtos.GenreDtos;
using BookReviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviewApp.Services;

public class GenreService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GenreService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<IEnumerable<GenreResponseDto>> GetAllAsync()
    {
        // var genres = await _context.Genres.ToListAsync();
        // return _mapper.Map<IEnumerable<GenreResponseDto>>(genres);

        return await _context.Genres
            .ProjectTo<GenreResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<GenreResponseDto?> GetAsync(Guid id)
    {
        return await _context.Genres
            .Where(g => g.Id == id)
            .ProjectTo<GenreResponseDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<GenreResponseDto> CreateAsync(GenreCreateDto createDto)
    {
        var genre = _mapper.Map<Genre>(createDto);
        await _context.Genres.AddAsync(genre);
        await _context.SaveChangesAsync();

        return _mapper.Map<GenreResponseDto>(genre);
    }

    public async Task<GenreResponseDto?> UpdateAsync(Guid id, GenreUpdateDto dto)
    {
        var genre = await _context.Genres.FindAsync(id);

        if(genre == null)
            return null;

        _mapper.Map(dto, genre);

        await _context.SaveChangesAsync();

        return _mapper.Map<GenreResponseDto>(genre);
    }

    public async Task DeleteAsync(Guid id)
    {
        var genre = await _context.Genres.FindAsync(id);

        if(genre == null)
            throw new KeyNotFoundException($"Genre with Id {id} not found.");

        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();
    }

}