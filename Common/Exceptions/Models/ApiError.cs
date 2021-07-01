using System.Collections.Generic;
using System.Linq;

namespace Common.Exceptions.Models
{
    public class ApiError
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
        public string Detail { get; set; }
        public ValidationErrorCollection Errors { get; set; }

        public ApiError(string message)
        {
            Message = message;
            IsError = true;
        }

        public ApiError(IEnumerable<ModelStateError> modelErrors, string message = "Please correct the specified errors and try again.")
        {
            if (modelErrors == null)
            {
                return;
            }

            var modelStateErrors = modelErrors.ToList();
            if (!modelStateErrors.Any())
            {
                Errors = null;
                return;
            }

            IsError = true;
            Message = message;

            Errors = new ValidationErrorCollection();

            foreach (ModelStateError res in modelStateErrors)
            {
                Errors.Add(new ValidationError
                {
                    Message = res.Message,
                    ControlID = res.Key,
                    ID = res.Key
                });
            }
        }
    }
}
