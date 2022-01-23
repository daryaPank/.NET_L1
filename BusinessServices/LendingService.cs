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
    public class LendingService:ILendingService
    {
        private readonly ILendingRepository _lendingRepository;
        private readonly IMapper _mapper;
        public LendingService(ILendingRepository repository, IMapper mapper)
        {
            _lendingRepository = repository;
            _mapper = mapper;
        }
        public LendingDto CreateLending(LendingDto lending)
        {
            var entity = _mapper.Map<Lending>(lending);
            _lendingRepository.CreateOrUpdate(entity);
            return _mapper.Map<LendingDto>(entity);
        }
       

        public IEnumerable<LendingDto> FindByReaderId(int readerId)
        {
            return _mapper.Map<IEnumerable<Lending>, IEnumerable<LendingDto>>(_lendingRepository.Query().Where(l => l.ReaderId == readerId));
        }
        public IEnumerable<LendingDto> FindByLibrarianId(int librarianId)
        {
            return _mapper.Map<IEnumerable<Lending>, IEnumerable<LendingDto>>(_lendingRepository.Query().Where(l => l.LibrarianId == librarianId));
        }

        public IEnumerable<LendingDto> GetByDateStart(DateTime start)
        {
            return _mapper.Map<IEnumerable<Lending>, IEnumerable<LendingDto>>(_lendingRepository.Query().Where(l => l.Start == start));
        }

        public LendingDto GetById(int id)
        {
            return _mapper.Map<Lending, LendingDto>(_lendingRepository.Read(id));
        }

        public IEnumerable<LendingDto> GetLendings()
        {
            var lendings = _lendingRepository.Query();
            return _mapper.Map<List<Lending>, IEnumerable<LendingDto>>(lendings);
        }

        void ILendingService.DeleteById(int id)
        {
            _lendingRepository.Delete(_lendingRepository.Read(id));
        }
    }
}
