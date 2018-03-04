using FormBuilder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormBuilder.DataService
{
    public interface IFormService
    {
        Form GetFormById(Guid id);
        bool Add(Form form);
        bool Update(Form form);
        bool Delete(Guid id);
    }
}
