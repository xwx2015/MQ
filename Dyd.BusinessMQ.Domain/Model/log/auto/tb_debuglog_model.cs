using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Dyd.BusinessMQ.Domain.Model
{
    /// <summary>
    /// tb_debuglog Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_debuglog_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int mqpathid { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string mqpath { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string methodname { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string info { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime createtime { get; set; }
        
    }
}