using System;
using AutoMapper;
using BookReviewApp.Dtos.BookDtos;
using BookReviewApp.Dtos.GenreDtos;
using BookReviewApp.Dtos.ReviewDtos;
using BookReviewApp.Dtos.UserDtos;
using BookReviewApp.Models;

namespace BookReviewApp.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        // Genre
        CreateMap<Genre, GenreResponseDto>();
        CreateMap<GenreCreateDto, Genre>();
        CreateMap<GenreUpdateDto, Genre>();

        // Book
        CreateMap<Book, BookResponseDto>()
            .ForMember(dest => dest.GenreDto, opt => opt.MapFrom(src => src.Genre));
        CreateMap<BookCreateDto, Book>();
        CreateMap<BookUpdateDto, Book>();

        // User
        CreateMap<User, UserResponseDto>()
            .ForMember(dest => dest.ReviewsDtos, opt => opt.MapFrom(src => src.Reviews));
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>();

        // Review
        CreateMap<Review, ReviewResponseDto>();
        CreateMap<ReviewCreateDto, Review>();
        CreateMap<ReviewUpdateDto, Review>();
    }

}
