using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace XXF.BaseService.MessageQuque.Model
{
    /// <summary>
    /// tb_datanode Data Structure.
    /// </summary>
    [Serializable]
    public partial class tb_datanode_model
    {
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
        
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int datanodepartition { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string serverip { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string username { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string password { get; set; }
        
    }
}