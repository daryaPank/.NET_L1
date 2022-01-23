using AutoMapper;
using Business.Entities;
using Business.Repositories.DataRepositories;
using Business.Services;
using BusinessInterop.Data;
using System.Collections.Generic;

namespace BusinessServices
{
    public class GenreService:IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenreService(IGenreRepository repository, IMapper mapper)
        {
            _genreRepository = repository;
            _mapper = mapper;
        }

        public GenreDto CreateGenre (GenreDto genre)
        {
            var entity = _mapper.Map<Genre>(genre);
            _genreRepository.CreateOrUpdate(entity);
            return _mapper.Map<GenreDto>(entity);
        }

        public GenreDto GetById(int id)
        {
            return _mapper.Map<Genre, GenreDto>(_genreRepository.Read(id));

        }

        public IEnumerable<GenreDto> GetGenres()
        {
            var genres = _genreRepository.Query();
            return _mapper.Map<List<Genre>, IEnumerable<GenreDto>>(genres);
        }
    }
}
