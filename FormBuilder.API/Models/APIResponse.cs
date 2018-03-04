using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormBuilder.API.Models
{
    public class APIResponse
    {
        public APIResponse()
        {
            this.Messages = new List<string>();
        }

        public APIResponse(object result)
        {
            this.Result = result;
            this.IsSuccess = true;
            this.Messages = new List<string>();
        }

        public APIResponse(object result, bool isSuccess, params string[] messages)
        {
            this.Messages = messages.ToList();
            this.IsSuccess = isSuccess;
            this.Result = result;
        }

        public APIResponse(params string[] messages)
        {
            this.Messages = messages.ToList();
            this.IsSuccess = false;
            this.Result = null;
        }

        public APIResponse(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
            this.Messages = new List<string>();
            this.Result = null;
        }

        public APIResponse(bool isSuccess, params string[] messages)
        {
            this.IsSuccess = isSuccess;
            this.Messages = new List<string>();
            this.Result = messages.ToList();
        }

        public List<string> Messages { get; set; }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
    }
}
