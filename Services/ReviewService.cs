using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookReviewApp.Data;
using BookReviewApp.Dtos.ReviewDtos;
using BookReviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviewApp.Services;

public class ReviewService : IReviewService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ReviewService (AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReviewResponseDto>> GetAllAsync()
    {
        return await _context.Reviews
            .ProjectTo<ReviewResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<ReviewResponseDto?> GetAsync(Guid id)
    {
        return await _context.Reviews
            .Where(r => r.Id == id)
            .ProjectTo<ReviewResponseDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<ReviewResponseDto> CreateAsync(ReviewCreateDto dto)
    {
        var review = _mapper.Map<Review>(dto);
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
        return _mapper.Map<ReviewResponseDto>(review);
    }

    public async Task<ReviewResponseDto?> UpdateAsync (Guid id, ReviewUpdateDto dto)
    {
        var review = await _context.Reviews.FindAsync(id);
        if(review == null)
            return null;

        _mapper.Map(dto, review);
        await _context.SaveChangesAsync();
        return _mapper.Map<ReviewResponseDto>(review);
    }

    public async Task DeleteAsync(Guid id)
    {
        var review = await _context.Reviews.FindAsync(id);

        if(review == null)
            throw new KeyNotFoundException($"Review with Id {id} not found.");

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();        
    }



    public async Task<IEnumerable<ReviewResponseDto>> GetByBookAsync(Guid bookId)
    {
        return await _context.Reviews
            .Where(r => r.BookId == bookId)
            .ProjectTo<ReviewResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<ReviewResponseDto>> GetByUserAsync(Guid userId)
    {
        return await _context.Reviews
            .Where(r => r.UserId == userId)
            .ProjectTo<ReviewResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
