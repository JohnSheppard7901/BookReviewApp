using System;
using AutoMapper;
using BookReviewApp.Dtos.GenreDtos;
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

        // // Book
        // CreateMap<Book, BookResponseDto>();
        // CreateMap<BookCreateDto, Book>();
        // CreateMap<BookUpdateDto, Book>();

        // // User
        // CreateMap<User, UserResponseDto>();
        // CreateMap<UserCreateDto, User>();
        // CreateMap<UserUpdateDto, User>();

        // // Review
        // CreateMap<Review, ReviewResponseDto>();
        // CreateMap<ReviewCreateDto, Review>();
        // CreateMap<ReviewUpdateDto, Review>();
    }

}
