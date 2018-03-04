using System;
using System.Collections.Generic;
using System.Text;
using FormBuilder.Data.Entities;

namespace FormBuilder.DataService
{
    public interface IFormAnswerService
    {
        IEnumerable<FormAnswer> GetFormAnswersByKey(Guid key);
        FormAnswer GetFormAnswerById(int id);
        bool Add(FormAnswer formAnswer);
        bool Update(FormAnswer formAnswer);
        bool Delete(int id);
    }
}
