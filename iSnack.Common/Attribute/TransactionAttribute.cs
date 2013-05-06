using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace iSnack.Common.Attribute
{
    /// <summary>
    /// 自动事务特性
    /// 标记此特性的方法将被自动添加到范围事务中执行
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class TransactionAttribute : global::System.Attribute
    {
        private TransactionScopeOption scopeOption = TransactionScopeOption.Required;
        public TransactionScopeOption ScopeOption { get { return scopeOption; } }

        private TransactionOptions tranOption = new TransactionOptions();
        public TransactionOptions TranOption { get { return tranOption; } }

        public TransactionAttribute() : this(TransactionManager.DefaultTimeout) { }

        public TransactionAttribute(TimeSpan timeOut, TransactionScopeOption scopeOption = TransactionScopeOption.Required, IsolationLevel isolationLevel = IsolationLevel.Chaos)
        {
            this.scopeOption = scopeOption;
            this.tranOption.IsolationLevel = isolationLevel;
            this.tranOption.Timeout = timeOut;
        }
    }
}
