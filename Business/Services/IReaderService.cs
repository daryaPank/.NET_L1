using BusinessInterop.Data;
using System.Collections.Generic;


namespace Business.Services
{
    public interface IReaderService
    {
        public ReaderDto CreateReader(ReaderDto reader);
        public IEnumerable<ReaderDto> GetReaders();

        public ReaderDto GetById(int id);

        public IEnumerable<ReaderDto>  GetByName(string name);

        public void DeleteReaderById(int id);
    }
}
