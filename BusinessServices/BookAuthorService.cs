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
    public class BookAuthorService:IBookAuthorService
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;
        private readonly IMapper _mapper;
        public BookAuthorService(IBookAuthorRepository repository, IMapper mapper)
        {
            _bookAuthorRepository = repository;
            _mapper = mapper;
        }

        public BookAuthorDto CreateBookAuthor(BookAuthorDto bookAuthor)
        {
            var entity = _mapper.Map<BookAuthor>(bookAuthor);
            _bookAuthorRepository.CreateOrUpdate(entity);
            return _mapper.Map<BookAuthorDto>(entity);
        }
       
        public IEnumerable<BookAuthorDto> GetAll()
        {
            return _mapper.Map<List<BookAuthor>, IEnumerable<BookAuthorDto>>(_bookAuthorRepository.Query());
        }

        


        public IEnumerable<BookAuthorDto> GetByBook(BookAuthorDto bookAuthor)
        {
            return _mapper.Map<IEnumerable<BookAuthor>, IEnumerable<BookAuthorDto>>(_bookAuthorRepository.Query()
                .Where(b => b.AuthorId == bookAuthor.AuthorId) );
        }
        public void DeleteById(int id)
        {
            _bookAuthorRepository.Delete(_bookAuthorRepository.Read(id));
        }

        public BookAuthorDto GetById(int id)
        {
            return _mapper.Map<BookAuthor, BookAuthorDto>(_bookAuthorRepository.Read(id));
        }
        
    }
}
