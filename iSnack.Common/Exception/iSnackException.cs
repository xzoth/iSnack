using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSnack.Common.Exception
{
    public partial class iSnackException : global::System.Exception
    {
        /// <summary>
        /// 异常编码
        /// </summary>
        public string Code { get { return this.code; } }
        private string code = iSnackException.I100000;

        public iSnackException(string message, string code) : this(message)
        {
            this.code = code;
        }

        public iSnackException() : base() { }

        public iSnackException(string message) : base(message) { }

        public iSnackException(string message, global::System.Exception innerException) : base(message, innerException) { }
        
        public iSnackException(string message, string code, global::System.Exception innerException) : this(message, innerException)
        {
            this.code = code;
        }
    }
}
