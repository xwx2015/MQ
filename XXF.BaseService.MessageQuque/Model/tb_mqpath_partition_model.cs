using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace XXF.BaseService.MessageQuque.Model
{
    /// <summary>
    /// tb_mqpath_partition Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_mqpath_partition_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// ĳ·���µ�mq��id
        /// </summary>
        public int mqpathid { get; set; }
        
        /// <summary>
        /// ����id���
        /// </summary>
        public int partitionid { get; set; }
        
        /// <summary>
        /// ����˳���(ĳ��·����mq��˳���)
        /// </summary>
        public int partitionindex { get; set; }
        
        /// <summary>
        /// ĳ·����mq��״̬,1 �����У�0 ������Ǩ�ƻ�ֹͣ��-1 ��ɾ��
        /// </summary>
        public Byte state { get; set; }
        
        /// <summary>
        /// ����ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
        /// </summary>
        public DateTime createtime { get; set; }
        
    }
}