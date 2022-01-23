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
    public class LibrarianService : ILibrarianService
    {
        private readonly ILibrarianRepository _librarianRepository;
        private readonly IMapper _mapper;
        public LibrarianService(ILibrarianRepository repository, IMapper mapper)
        {
            _librarianRepository = repository;
            _mapper = mapper;
        }
        public LibrarianDto CreateLibrarian(LibrarianDto librarian)
        {
            var entity = _mapper.Map<Librarian>(librarian);
            _librarianRepository.CreateOrUpdate(entity);
            return _mapper.Map<LibrarianDto>(entity);
        }

        public LibrarianDto GetById(int id)
        {
            return _mapper.Map<Librarian, LibrarianDto>(_librarianRepository.Query().FirstOrDefault(l => l.Id == id));
        }

        public LibrarianDto GetByName(string name)
        {
            return _mapper.Map<Librarian, LibrarianDto>(_librarianRepository.Query().Where(l => l.Name.ToUpper() == name.ToUpper()).FirstOrDefault());
        }

        public IEnumerable<LibrarianDto> GetLibrarians()
        {
            var librarians = _librarianRepository.Query();
            return _mapper.Map<List<Librarian>, IEnumerable<LibrarianDto>>(librarians);
        }

        public void DeleteById(int id)
        {
            _librarianRepository.Delete(_librarianRepository.Read(id));
        }
    }
}
