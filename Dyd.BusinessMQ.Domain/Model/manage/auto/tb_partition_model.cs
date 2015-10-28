using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Dyd.BusinessMQ.Domain.Model
{
    /// <summary>
    /// tb_partition Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_partition_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// ����id��,����1+���ݽڵ���+��������
        /// </summary>
        public int partitionid { get; set; }
        
        /// <summary>
        /// �Ƿ���ʹ��
        /// </summary>
        public bool isused { get; set; }
        
        /// <summary>
        /// ����ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
        /// </summary>
        public DateTime createtime { get; set; }
        
    }
}