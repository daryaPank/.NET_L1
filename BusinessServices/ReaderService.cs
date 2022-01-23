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
    public class ReaderService:IReaderService
    {
        private readonly IReaderRepository _readerRepository;
        private readonly IMapper _mapper;
        public ReaderService(IReaderRepository repository, IMapper mapper)
        {
            _readerRepository = repository;
            _mapper = mapper;
        }
        public ReaderDto CreateReader(ReaderDto reader)
        {
            var entity = _mapper.Map<Reader>(reader);
            _readerRepository.CreateOrUpdate(entity);
            return _mapper.Map<ReaderDto>(entity);
        }

        public void DeleteReaderById(int id)
        {
            _readerRepository.Delete(_readerRepository.Read(id));
        }

        
        public ReaderDto GetById(int id)
        {
            return _mapper.Map<Reader, ReaderDto>(_readerRepository.Read(id));
        }

        public IEnumerable<ReaderDto> GetByName(string name)
        {
            return _mapper.Map<IEnumerable<Reader>, IEnumerable<ReaderDto>>(_readerRepository.Query().Where(r => r.Name.Contains(name, System.StringComparison.InvariantCultureIgnoreCase)));
        }

        public IEnumerable<ReaderDto> GetReaders()
        {
            var readers = _readerRepository.Query();
            return _mapper.Map<List<Reader>, IEnumerable<ReaderDto>>(readers);
        }
    }
}
