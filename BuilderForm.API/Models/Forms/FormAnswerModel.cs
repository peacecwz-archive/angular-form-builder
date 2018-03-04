using System;

namespace BuilderForm.API.Models.Forms
{
    public class FormAnswerModel
    {
        public Guid FormId { get; set; }
        public string Answer { get; set; }
    }
}