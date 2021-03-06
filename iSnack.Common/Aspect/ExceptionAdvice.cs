﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Aop;
using iSnack.Common.Exception;
using log4net;
using System.Reflection;
using Newtonsoft.Json;
using iSnack.Common.Attribute;

namespace iSnack.Common.Aspect
{
    public class ExceptionAdvice : IThrowsAdvice
    {
        public void AfterThrowing(global::System.Exception e)
        {
            ExceptionAttribute[] exAttributeInfo = e.TargetSite.GetCustomAttributes(typeof(ExceptionAttribute), false) as ExceptionAttribute[];
            ExceptionAttribute exAttribute = exAttributeInfo[0];

            //登记异常
            ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            logger.ErrorFormat("捕获异常：{0}， 发生于{1}.{2}， 异常信息：{3}, 异常数据：{4}， 调用堆栈：{5}", 
                e.Source, 
                e.TargetSite.DeclaringType.FullName, 
                e.TargetSite.Name,
                e.Message,
                JsonConvert.SerializeObject(e.Data),
                string.Empty);//TODO: 记录异常堆栈 e.StackTrace

            //抛出 iSnackException
            throw new iSnackException(exAttribute.Code, e);
        }
    }
}
