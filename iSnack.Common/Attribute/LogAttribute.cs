using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using log4net.Core;

namespace iSnack.Common.Attribute
{
    /// <summary>
    /// 自动日志特性
    /// 标记此特性的方法将会自动记录日志
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class LogAttribute : global::System.Attribute
    {
        public LogAttribute() { }

        public LogAttribute(LogLevel level) { this.level = level; }

        /// <summary>
        /// 日志记录级别
        /// 默认为LogLevel.Debug
        /// </summary>
        public LogLevel LogLevel { get { return this.level; } }
        private LogLevel level = LogLevel.Debug;
    }

    /// <summary>
    /// 日志记录级别
    /// </summary>
    public enum LogLevel : int
    {
        /// <summary>
        /// 调试
        /// </summary>
        Debug,
        /// <summary>
        /// 信息
        /// </summary>
        Info,
        /// <summary>
        /// 警告
        /// </summary>
        Warn,
        /// <summary>
        /// 错误
        /// </summary>
        Error,
        /// <summary>
        /// 致命错误
        /// </summary>
        Fatal
    }
}
