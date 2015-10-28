using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Data;
using System.Text;
using XXF.Extensions;
using XXF.Db;
using Dyd.BusinessMQ.Domain.Model;

namespace Dyd.BusinessMQ.Domain.Dal
{
	/*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
	public partial class tb_mqpath_partition_dal
    {
        public virtual bool Add(DbConn PubConn, tb_mqpath_partition_model model)
        {

            List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
					
					//ĳ·���µ�mq��id
					new ProcedureParameter("@mqpathid",    model.mqpathid),
					//����id���
					new ProcedureParameter("@partitionid",    model.partitionid),
					//����˳���(ĳ��·����mq��˳���)
					new ProcedureParameter("@partitionindex",    model.partitionindex),
					//ĳ·����mq��״̬,1 �����У�0 ������Ǩ�ƻ�ֹͣ��-1 ��ɾ��
					new ProcedureParameter("@state",    model.state),
					//����ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@createtime",    model.createtime)   
                };
            int rev = PubConn.ExecuteSql(@"insert into tb_mqpath_partition(mqpathid,partitionid,partitionindex,state,createtime)
										   values(@mqpathid,@partitionid,@partitionindex,@state,@createtime)", Par);
            return rev == 1;

        }

        public virtual bool Edit(DbConn PubConn, tb_mqpath_partition_model model)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>()
            {
                    
					//ĳ·���µ�mq��id
					new ProcedureParameter("@mqpathid",    model.mqpathid),
					//����id���
					new ProcedureParameter("@partitionid",    model.partitionid),
					//����˳���(ĳ��·����mq��˳���)
					new ProcedureParameter("@partitionindex",    model.partitionindex),
					//ĳ·����mq��״̬,1 �����У�0 ������Ǩ�ƻ�ֹͣ��-1 ��ɾ��
					new ProcedureParameter("@state",    model.state),
					//����ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@createtime",    model.createtime)
            };
			Par.Add(new ProcedureParameter("@id",  model.id));

            int rev = PubConn.ExecuteSql("update tb_mqpath_partition set mqpathid=@mqpathid,partitionid=@partitionid,partitionindex=@partitionindex,state=@state,createtime=@createtime where id=@id", Par);
            return rev == 1;

        }

        public virtual bool Delete(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id",  id));

            string Sql = "delete from tb_mqpath_partition where id=@id";
            int rev = PubConn.ExecuteSql(Sql, Par);
            if (rev == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public virtual tb_mqpath_partition_model Get(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id", id));
            StringBuilder stringSql = new StringBuilder();
            stringSql.Append(@"select s.* from tb_mqpath_partition s where s.id=@id");
            DataSet ds = new DataSet();
            PubConn.SqlToDataSet(ds, stringSql.ToString(), Par);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
				return CreateModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }

		public virtual tb_mqpath_partition_model CreateModel(DataRow dr)
        {
            var o = new tb_mqpath_partition_model();
			
			//
			if(dr.Table.Columns.Contains("id"))
			{
				o.id = dr["id"].Toint();
			}
			//ĳ·���µ�mq��id
			if(dr.Table.Columns.Contains("mqpathid"))
			{
				o.mqpathid = dr["mqpathid"].Toint();
			}
			//����id���
			if(dr.Table.Columns.Contains("partitionid"))
			{
				o.partitionid = dr["partitionid"].Toint();
			}
			//����˳���(ĳ��·����mq��˳���)
			if(dr.Table.Columns.Contains("partitionindex"))
			{
				o.partitionindex = dr["partitionindex"].Toint();
			}
			//ĳ·����mq��״̬,1 �����У�0 ������Ǩ�ƻ�ֹͣ��-1 ��ɾ��
			if(dr.Table.Columns.Contains("state"))
			{
				o.state = dr["state"].ToByte();
			}
			//����ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
			if(dr.Table.Columns.Contains("createtime"))
			{
				o.createtime = dr["createtime"].ToDateTime();
			}
			return o;
        }
    }
}