using System;
using System.Collections.Generic;
using System.Text;

namespace FormBuilder.Data.Entities
{
    public class FormAnswer : BaseEntity<int>
    {
        public Guid FormId { get; set; }
        public string Answer { get; set; }

        //Relations
        public virtual Form Form { get; set; }
    }
}
