using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace XXF.BaseService.MessageQuque.Model
{
    /// <summary>
    /// tb_mqerror Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_mqerror_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// 
        /// </summary>
        public long ID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Byte TryCount { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Byte MQType { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string MQPath { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string MQMsgJson { get; set; }
        
    }
}