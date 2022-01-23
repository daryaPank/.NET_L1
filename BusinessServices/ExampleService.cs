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
    public class ExampleService : IExampleService
    {
        private readonly IExampleRepository _exampleRepository;
        private readonly IMapper _mapper;

        public ExampleService(IExampleRepository repository, IMapper mapper)
        {
            _exampleRepository = repository;
            _mapper = mapper;
        }
        public ExampleDto CreateExample(ExampleDto example)
        {
            var entity = _mapper.Map<Example>(example);

            _exampleRepository.CreateOrUpdate(entity);

            return _mapper.Map<ExampleDto>(entity);
        }

        public void DeleteExampleById(int id)
        {
            _exampleRepository.Delete(_exampleRepository.Read(id));
        }

        public ExampleDto GetById(int id)
        {
            return _mapper.Map<Example, ExampleDto>(_exampleRepository.Read(id));
        }

        public ExampleDto GetByNumber(int number)
        {
            return _mapper.Map<Example, ExampleDto>(_exampleRepository.Query().Where(u => u.Number == number).FirstOrDefault());
        }

        public IEnumerable<ExampleDto> GetExamples()
        {
            var examples = _exampleRepository.Query();
            return _mapper.Map<List<Example>, IEnumerable<ExampleDto>>(examples);
        }
    }
}
