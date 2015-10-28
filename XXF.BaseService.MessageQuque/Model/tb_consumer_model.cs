using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace XXF.BaseService.MessageQuque.Model
{
    /// <summary>
    /// tb_consumer Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_consumer_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// ��������ʱid(������������Ψһ,Guidתlong)
        /// </summary>
        public long tempid { get; set; }
        
        /// <summary>
        /// ������clinet��id
        /// </summary>
        public int consumerclientid { get; set; }
        
        /// <summary>
        /// ֧�ֵķ���˳���(֧�ֶ��˳���)
        /// </summary>
        public string partitionindexs { get; set; }
        
        /// <summary>
        /// �ͻ�������
        /// </summary>
        public string clientname { get; set; }
        
        /// <summary>
        /// �������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
        /// </summary>
        public DateTime lastheartbeat { get; set; }
        
        /// <summary>
        /// ��һ�θ���ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
        /// </summary>
        public DateTime lastupdatetime { get; set; }
        
        /// <summary>
        /// �ͻ��˴���ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
        /// </summary>
        public DateTime createtime { get; set; }
        
    }
}