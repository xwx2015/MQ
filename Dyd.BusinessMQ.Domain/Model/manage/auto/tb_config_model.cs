using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Dyd.BusinessMQ.Domain.Model
{
    /// <summary>
    /// tb_config Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_config_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// ����Key
        /// </summary>
        public string key { get; set; }
        
        /// <summary>
        /// ����Value
        /// </summary>
        public string value { get; set; }
        
        /// <summary>
        /// ���ñ�ע��Ϣ
        /// </summary>
        public string remark { get; set; }
        
    }
}