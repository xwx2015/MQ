using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Dyd.BusinessMQ.Domain.Model
{
    /// <summary>
    /// tb_producter Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_producter_model
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
        /// ����������
        /// </summary>
        public string productername { get; set; }
        
        /// <summary>
        /// ip��ַ
        /// </summary>
        public string ip { get; set; }
        
        /// <summary>
        /// ����id
        /// </summary>
        public int mqpathid { get; set; }
        
        /// <summary>
        /// �������������ʱ��
        /// </summary>
        public DateTime lastheartbeat { get; set; }
        
        /// <summary>
        /// �����ߴ���ʱ��
        /// </summary>
        public DateTime createtime { get; set; }
        
    }
}