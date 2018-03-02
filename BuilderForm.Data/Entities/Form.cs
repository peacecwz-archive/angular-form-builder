using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderForm.Data.Entities
{
    public class Form : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string FormSchema { get; set; }

        //Relations
        public virtual List<FormAnswer> FormAnswers { get; set; }
    }
}
