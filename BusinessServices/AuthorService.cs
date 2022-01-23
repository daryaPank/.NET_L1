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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _authorRepository = repository;
            _mapper = mapper;
        }
        public AuthorDto CreateAuthor(AuthorDto author)
        {
            var entity = _mapper.Map<Author>(author);
            _authorRepository.CreateOrUpdate(entity);
            return _mapper.Map<AuthorDto>(entity);
        }

        public IEnumerable<AuthorDto> FindByCountry(string country)
        {
            return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDto>>(_authorRepository.Query().Where(a => a.Country.Contains(country, System.StringComparison.InvariantCultureIgnoreCase)));
        }

        public IEnumerable<AuthorDto> GetAuthors()
        {
            var authors = _authorRepository.Query();
            return _mapper.Map<List<Author>, IEnumerable<AuthorDto>>(authors);
        }

        public AuthorDto GetById(int id)
        {
            return _mapper.Map<Author, AuthorDto>(_authorRepository.Query().FirstOrDefault(a => a.Id == id));
        }

        public AuthorDto GetByName(string name)
        {
            return _mapper.Map<Author, AuthorDto>(_authorRepository.Query().Where(u => u.Name.ToUpper() == name.ToUpper()).FirstOrDefault());
        }
    }
}
