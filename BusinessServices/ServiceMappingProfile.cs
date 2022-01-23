using Business.Entities;
using BusinessInterop.Data;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace BusinessServices
{
    public class ServiceMappingProfile:Profile
    {
        public ServiceMappingProfile()
        {       
            // from entity to dto
            CreateMap<Author, AuthorDto>();
            CreateMap<Book, BookDto>();
            CreateMap<BookAuthor, BookAuthorDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Example, ExampleDto>();
            CreateMap<Lending, LendingDto>();
            CreateMap<Librarian, LibrarianDto>();
            CreateMap<Reader, ReaderDto>();

            //from dto to entity
            CreateMap<AuthorDto, Author>();
            CreateMap<BookDto, Book>();
            CreateMap<BookAuthorDto, BookAuthor>();
            CreateMap<GenreDto, Genre>();
            CreateMap<ExampleDto, Example>();
            CreateMap<LendingDto, Lending>();
            CreateMap<LibrarianDto, Librarian>();
            CreateMap<ReaderDto, Reader>();
        }
    }
}
