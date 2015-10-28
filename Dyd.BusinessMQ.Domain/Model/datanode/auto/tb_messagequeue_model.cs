using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Dyd.BusinessMQ.Domain.Model
{
    /// <summary>
    /// tb_messagequeue Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_messagequeue_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// ��Ϣid��,����1+���ݽڵ���+��������+ʱ�������+����id
        /// </summary>
        public long id { get; set; }
        
        /// <summary>
        /// mq�������߶˵Ĵ���ʱ�䣨�����߶�ʱ����ܸ�������ʱ�䲻һ�£�
        /// </summary>
        public DateTime mqcreatetime { get; set; }
        
        /// <summary>
        /// sql���ݽڵ㴦�Ĵ���ʱ��
        /// </summary>
        public DateTime sqlcreatetime { get; set; }
        
        /// <summary>
        /// ��Ϣ����,0=�ɶ���Ϣ��1=��Ǩ����Ϣ
        /// </summary>
        public Byte state { get; set; }
        
        /// <summary>
        /// ��Դ����:0 ��ʾ ��������,1 ��ʾ Ǩ����Ϣ
        /// </summary>
        public Byte source { get; set; }
        
        /// <summary>
        /// ��Ϣ�壨��Ϣ����,��json��ʽ�洢��Ϊ���Ķ����ǣ�
        /// </summary>
        public string message { get; set; }
        
    }
}