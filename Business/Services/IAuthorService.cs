using BusinessInterop.Data;
using System.Collections.Generic;



namespace Business.Services
{
    public interface IAuthorService
    {
        public AuthorDto CreateAuthor(AuthorDto author);
        
        public IEnumerable<AuthorDto> GetAuthors();
        public AuthorDto GetById(int id);
        public AuthorDto GetByName(string name);

        public IEnumerable<AuthorDto> FindByCountry(string country);

    }
}
