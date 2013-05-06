using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iSnack.Common.Exception;

namespace iSnack.Common.Attribute
{
    /// <summary>
    /// 自动异常处理特性
    /// 标记此特性的方法将会自动处理异常
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ExceptionAttribute : global::System.Attribute
    {
        private string code = string.Empty;
        public string Code { get { return this.code; } }

        public ExceptionAttribute() { }

        public ExceptionAttribute(string code) { this.code = code; }
    }
}
