using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Enums;

namespace WebApplication.Core.Exceptions
{
    [Serializable]
    public class ArticleException : ApplicationException
    {

        private Dictionary<UserErrorType, string> errors = new Dictionary<UserErrorType, string>
        {
            { UserErrorType.EmailBusy, "Sorry, your email is busy!"},
            { UserErrorType.EmailNotExists, "Email is not found!"},
            { UserErrorType.IncorectPassword, "Your password is not correct!"},
        };

        private string errorMessage;

        public ArticleException(UserErrorType errorType)
        {
            if (errors.ContainsKey(errorType))
            {
                errorMessage = errors[errorType];
            }
            else
            {
                errorMessage = "Unexpected Error";
            }
        }

        public override string Message
        {
            get
            {
                return errorMessage;
            }

        }
    }
}
