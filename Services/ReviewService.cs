using AutoMapper;
using BookReviewApp.Data;
using BookReviewApp.Dtos.ReviewDtos;

namespace BookReviewApp.Services;

public class ReviewService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ReviewService (AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // public async Task<IEnumerable<ReviewResponseDto>> GetAllAsync()
    // {
    //     return responseDtoList;
    // }

    // public async Task<ReviewResponseDto> GetAsync(Guid id)
    // {
    //     return responseDto;
    // }

    // public async Task<ReviewResponseDto> CreateAsync(ReviewCreateDto dto)
    // {
    //     return responseDto;
    // }

    // public async Task<ReviewResponseDto> UpdateAsync (Guid id, ReviewUpdateDto dto)
    // {
    //     return responseDto;
    // }

    public async Task DeleteAsync(Guid id)
    {
        
    }
}
