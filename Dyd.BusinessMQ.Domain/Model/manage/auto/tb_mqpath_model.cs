using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Dyd.BusinessMQ.Domain.Model
{
    /// <summary>
    /// tb_mqpath Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_mqpath_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// mq·��
        /// </summary>
        public string mqpath { get; set; }
        
        /// <summary>
        /// ��·����mq,����������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
        /// </summary>
        public DateTime lastupdatetime { get; set; }
        
        /// <summary>
        /// mq����ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
        /// </summary>
        public DateTime createtime { get; set; }
        
    }
}