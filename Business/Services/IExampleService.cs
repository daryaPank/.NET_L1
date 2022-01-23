using System;
using System.Collections.Generic;
using BusinessInterop.Data;

namespace Business.Services
{
    public interface IExampleService
    {
        public ExampleDto CreateExample(ExampleDto example);
        public void DeleteExampleById(int id);
        public IEnumerable<ExampleDto> GetExamples();
        public ExampleDto GetById(int id);
        public ExampleDto GetByNumber(int number);
    }
}
