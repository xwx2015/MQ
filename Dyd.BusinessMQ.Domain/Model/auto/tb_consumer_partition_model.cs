using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Dyd.BusinessMQ.Domain.Model
{
    /// <summary>
    /// tb_consumer_partition Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_consumer_partition_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// �����߿ͻ���ID
        /// </summary>
        public int consumerclientid { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int partitionindex { get; set; }
        
        /// <summary>
        /// ������ID
        /// </summary>
        public int partitionid { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public long lastconsumertempid { get; set; }
        
        /// <summary>
        /// ������ѵ�MQID
        /// </summary>
        public long lastmqid { get; set; }
        
        /// <summary>
        /// ���������ִ��ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
        /// </summary>
        public DateTime lastupdatetime { get; set; }
        
        /// <summary>
        /// �����߷�������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
        /// </summary>
        public DateTime createtime { get; set; }
        
    }
}