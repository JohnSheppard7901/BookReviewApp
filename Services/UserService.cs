using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookReviewApp.Data;
using BookReviewApp.Dtos.UserDtos;
using BookReviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviewApp.Services;

public class UserService
{

    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UserService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
    {
        return await _context.Users
            .ProjectTo<UserResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<UserResponseDto?> GetAsync(Guid id)
    {
        return await _context.Users
            .Where(u => u.Id == id)
            .ProjectTo<UserResponseDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<UserResponseDto> CreateAsync(UserCreateDto dto)
    {
        User user = _mapper.Map<User>(dto);
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task<UserResponseDto?> UpdateAsync (Guid id, UserUpdateDto dto)
    {
        var user = await _context.Users.FindAsync(id);
        if(user == null)
            return null;
        
        _mapper.Map(dto, user);
        await _context.SaveChangesAsync();

        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if(user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
            
    }

}
