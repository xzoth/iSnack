using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSnack.Service.Data
{
    /// <summary>
    /// 应用层消息
    /// </summary>
    public abstract class iSnackMessage<T> where T : iSnackEntity
    {
        public bool IsSuccess { get; set; }
        
        public string Text { get; set; }

        public T Data
        { 
            get; 
            set;
        }
    }
}
