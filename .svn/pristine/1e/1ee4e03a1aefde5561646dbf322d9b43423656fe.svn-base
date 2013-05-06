using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AopAlliance.Intercept;
using System.Transactions;
using iSnack.Common.Attribute;

namespace iSnack.Common.Aspect
{
    /// <summary>
    /// 自动事务处理
    /// </summary>
    public class TransactionAdvice : IMethodInterceptor
    {
        public virtual object Invoke(IMethodInvocation invocation)
        {
            object returnValue = null;

            TransactionAttribute[] tranAttributeInfo = invocation.Method.GetCustomAttributes(typeof(TransactionAttribute), false) as TransactionAttribute[];
            TransactionAttribute attribute = tranAttributeInfo[0];

            using (TransactionScope tran = new TransactionScope(attribute.ScopeOption, attribute.TranOption))
            {
                returnValue = invocation.Proceed();
                tran.Complete();
            }

            return returnValue;
        }
    }
}
