using System;
using System.Collections.Generic;
using System.Text;

namespace FormBuilder.Data.Entities
{
    public class Form : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string FormSchema { get; set; }
        public Guid Key { get; set; }

        //Relations
        public virtual List<FormAnswer> FormAnswers { get; set; }
    }
}
