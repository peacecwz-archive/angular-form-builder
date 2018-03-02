using System;
using System.Collections.Generic;
using System.Text;
using BuilderForm.Data.Entities;

namespace BuilderForm.DataService
{
    public interface IFormAnswerService
    {
        IEnumerable<FormAnswer> GetFormAnswersByFormId(Guid formId);
        FormAnswer GetFormAnswerById(int id);
        bool Add(FormAnswer formAnswer);
        bool Update(FormAnswer formAnswer);
        bool Delete(int id);
    }
}
