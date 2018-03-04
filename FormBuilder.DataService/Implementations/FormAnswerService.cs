using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormBuilder.Data.Entities;
using FormBuilder.Repository;

namespace FormBuilder.DataService.Implementations
{
    public class FormAnswerService : IFormAnswerService
    {
        private readonly IRepository<Form> formRepository;
        private readonly IRepository<FormAnswer> repository;
        public FormAnswerService(IRepository<Form> formRepository, IRepository<FormAnswer> repository)
        {
            this.repository = repository;
            this.formRepository = formRepository;
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

        public IEnumerable<FormAnswer> GetFormAnswersByKey(Guid key)
        {
            var form = formRepository.SingleWithDefault<Guid>(x => x.Key == key, x => x.FormAnswers);
            var answers= form.FormAnswers.ToList();
            answers.ForEach(x => { x.Form = null; });
            return answers;
        }

        public bool Update(FormAnswer formAnswer)
        {
            return repository.Update(formAnswer);
        }
    }
}
