using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Reflection;
using AopAlliance.Intercept;
using iSnack.Common.Attribute;
using iSnack.Common.Exception;
using Newtonsoft.Json;
using System.Resources;

namespace iSnack.Common.Aspect
{
    /// <summary>
    /// 自动日志记录
    /// </summary>
    public class LogAdvice : IMethodInterceptor
    {
        internal LogAttribute LogAttribute { get; set; }
        internal ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public virtual object Invoke(IMethodInvocation invocation)
        {
            LogAttribute[] logAttributeInfo = invocation.Method.GetCustomAttributes(typeof(LogAttribute), false) as LogAttribute[];
            LogAttribute = logAttributeInfo[0];

            DoBeforeLog(invocation.Method, invocation.Arguments);
            object returnValue = invocation.Proceed();
            DoAfterLog(invocation.Method, returnValue);

            return returnValue;
        }
        
        private void LogByLevel(LogLevel level, string strMsg)
        {
            //TODO: sync Log
            switch (LogAttribute.LogLevel)
            {
                case LogLevel.Debug: if(logger.IsDebugEnabled) logger.Debug(strMsg); break;
                case LogLevel.Error: if(logger.IsErrorEnabled) logger.Error(strMsg); break;
                case LogLevel.Info: if (logger.IsInfoEnabled) logger.Info(strMsg); break;
                case LogLevel.Warn: if (logger.IsWarnEnabled) logger.Warn(strMsg); break;
                case LogLevel.Fatal: if (logger.IsFatalEnabled) logger.Fatal(strMsg); break;
                default:
                    //throw new iSnackException(iSnackExceptionString.I100000 + LogAttribute.LogLevel.ToString(),
                    //                          iSnackException.I100001);
                    logger.Debug(strMsg);
                    break;
            }
        }

        private void DoBeforeLog(MethodInfo methodInfo, object[] args)
        {
            string strMsg = string.Format("准备调用方法：{0}.{1}, 参数列表：{2}", 
                methodInfo.DeclaringType.FullName, methodInfo.Name, JsonConvert.SerializeObject(args));
            LogByLevel(LogAttribute.LogLevel, strMsg);
        }

        private void DoAfterLog(MethodInfo methodInfo, object returnValue)
        {
            string strMsg = string.Format("方法{0}.{1}执行完毕，返回值：{2}", 
                methodInfo.DeclaringType.FullName, methodInfo.Name, JsonConvert.SerializeObject(returnValue));
            LogByLevel(LogAttribute.LogLevel, strMsg);
        }
    }
}
