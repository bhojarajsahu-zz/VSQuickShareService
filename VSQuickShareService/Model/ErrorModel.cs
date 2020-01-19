using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VSQuickShareService.Model
{
    public class ErrorModel
    {
        private string errorCode;
        private string errorMessage;

        public string ErrorCode
        {
            get
            {
                return errorCode;
            }

            set
            {
                errorCode = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }

            set
            {
                errorMessage = value;
            }
        }
    }
}