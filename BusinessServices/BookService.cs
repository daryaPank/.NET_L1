using AutoMapper;
using Business.Entities;
using Business.Repositories.DataRepositories;
using Business.Services;
using BusinessInterop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices
{
    public class BookService:IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository repository, IMapper mapper)
        {
            _bookRepository = repository;
            _mapper = mapper;
        }
        public BookDto CreateBook(BookDto book)
        {
            var entity = _mapper.Map<Book>(book);
            _bookRepository.CreateOrUpdate(entity);
            return _mapper.Map<BookDto>(entity);
        }
        
        public void DeleteBookById(int id)
        {
            _bookRepository.Delete(_bookRepository.Read(id));
        }
        public IEnumerable<BookDto> GetBooks()
        {
            var books = _bookRepository.Query();
            return _mapper.Map<List<Book>, IEnumerable<BookDto>>(books);
        }

        public BookDto GetById(int id)
        {
            return _mapper.Map<Book, BookDto>(_bookRepository.Read(id));
        }

        public IEnumerable<BookDto> GetByYear(int year)
        {
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(_bookRepository.Query().Where(b => b.Year==year));
        }

        public BookDto GetByName(string name)
        {
            return _mapper.Map<Book, BookDto>(_bookRepository.Query().Where(u => u.Name.ToUpper() == name.ToUpper()).FirstOrDefault());
        }

        public IEnumerable<BookDto> FindByGenre(GenreDto genre)
        {
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(_bookRepository.Query().Where(b => b.GenreId == genre.Id));
        }
    }
}
