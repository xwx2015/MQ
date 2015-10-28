using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Dyd.BusinessMQ.Domain.Model
{
    /// <summary>
    /// tb_partition_messagequeue_report Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_partition_messagequeue_report_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// �������
        /// </summary>
        public int partitionid { get; set; }
        
        /// <summary>
        /// ����
        /// </summary>
        public DateTime day { get; set; }
        
        /// <summary>
        /// ���������Ϣid
        /// </summary>
        public long mqmaxid { get; set; }
        
        /// <summary>
        /// mq��С��Ϣid
        /// </summary>
        public long mqminid { get; set; }
        
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public int mqcount { get; set; }
        
        /// <summary>
        /// ��ǰ����ɨ��������ʱ��
        /// </summary>
        public DateTime lastupdatetime { get; set; }
        
        /// <summary>
        /// ��ǰ����ɨ�贴��ʱ��
        /// </summary>
        public DateTime createtime { get; set; }
        
    }
}