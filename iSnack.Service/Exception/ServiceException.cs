using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iSnack.Common.Exception;

namespace iSnack.Service.Exception
{
    public partial class ServiceException : iSnackException
    {
        public ServiceException() : base() { }
        public ServiceException(string message) : base(message) { }
        public ServiceException(string message, global::System.Exception innerException) : base(message, innerException) { }
    }
}
