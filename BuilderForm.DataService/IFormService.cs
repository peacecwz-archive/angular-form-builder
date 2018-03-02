using BuilderForm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderForm.DataService
{
    public interface IFormService
    {
        Form GetFormById(Guid id);
        bool Add(Form form);
        bool Update(Form form);
        bool Delete(Guid id);
    }
}
