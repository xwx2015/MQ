using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Dyd.BusinessMQ.Domain.Model
{
    /// <summary>
    /// tb_consumer_client Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_consumer_client_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// �ͻ��ˣ�������client����ͬҵ��������ע�����һ�£�
        /// </summary>
        public string client { get; set; }
        
        /// <summary>
        /// ��ǰ�����ߴ���ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
        /// </summary>
        public DateTime createtime { get; set; }
        
    }
}