using BusinessInterop.Data;
using System;
using System.Collections.Generic;

namespace Business.Services
{
    public interface ILendingService
    {
        public LendingDto CreateLending(LendingDto lending);
        public IEnumerable<LendingDto> GetLendings();
        public LendingDto GetById(int id);
        public IEnumerable<LendingDto> GetByDateStart(DateTime start);
        public void DeleteById(int id);
        public IEnumerable<LendingDto> FindByReaderId(int readerId);
        public IEnumerable<LendingDto> FindByLibrarianId(int librarianId);
    }
}
