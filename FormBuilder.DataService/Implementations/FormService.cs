using System;
using System.Collections.Generic;
using System.Text;
using FormBuilder.Data.Entities;
using FormBuilder.Repository;

namespace FormBuilder.DataService.Implementations
{
    public class FormService : IFormService
    {
        private readonly IRepository<Form> formRepository;
        public FormService(IRepository<Form> formRepository)
        {
            this.formRepository = formRepository;
        }

        public bool Add(Form form)
        {
            return formRepository.Add(form);
        }

        public bool Delete(Guid id)
        {
            var form = GetFormById(id);
            if (form == null) return false;

            return formRepository.Delete<Guid>(form);
        }

        public Form GetFormById(Guid id)
        {
            return formRepository.GetById(id);
        }

        public bool Update(Form form)
        {
            return formRepository.Update(form);
        }
    }
}
