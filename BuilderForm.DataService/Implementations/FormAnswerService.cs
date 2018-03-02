using System;
using System.Collections.Generic;
using System.Text;
using BuilderForm.Data.Entities;
using BuilderForm.Repository;

namespace BuilderForm.DataService.Implementations
{
    public class FormAnswerService : IFormAnswerService
    {
        private readonly IRepository<FormAnswer> repository;
        public FormAnswerService(IRepository<FormAnswer> repository)
        {
            this.repository = repository;
        }

        public bool Add(FormAnswer formAnswer)
        {
            return repository.Add(formAnswer);
        }

        public bool Delete(int id)
        {
            var formAnswer = GetFormAnswerById(id);
            if (formAnswer == null) return false;

            return repository.Delete<int>(formAnswer);
        }

        public FormAnswer GetFormAnswerById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<FormAnswer> GetFormAnswersByFormId(Guid formId)
        {
            return repository.WhereWithDefault<int>(x => x.FormId == formId);
        }

        public bool Update(FormAnswer formAnswer)
        {
            return repository.Update(formAnswer);
        }
    }
}
