using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSnack.Common.Attribute
{
    /// <summary>
    /// 自动权限校验特性
    /// 标记此特性以请求权限校验
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Class | 
                    AttributeTargets.Method | 
                    AttributeTargets.Field | 
                    AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PermissionAttribute : global::System.Attribute
    {

    }
}
