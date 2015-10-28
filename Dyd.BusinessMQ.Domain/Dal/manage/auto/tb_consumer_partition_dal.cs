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
	public partial class tb_consumer_partition_dal
    {
        public virtual bool Add(DbConn PubConn, tb_consumer_partition_model model)
        {

            List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
					
					//�����߿ͻ���ID
					new ProcedureParameter("@consumerclientid",    model.consumerclientid),
					//
					new ProcedureParameter("@partitionindex",    model.partitionindex),
					//������ID
					new ProcedureParameter("@partitionid",    model.partitionid),
					//
					new ProcedureParameter("@lastconsumertempid",    model.lastconsumertempid),
					//������ѵ�MQID
					new ProcedureParameter("@lastmqid",    model.lastmqid),
					//���������ִ��ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@lastupdatetime",    model.lastupdatetime),
					//�����߷�������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@createtime",    model.createtime)   
                };
            int rev = PubConn.ExecuteSql(@"insert into tb_consumer_partition(consumerclientid,partitionindex,partitionid,lastconsumertempid,lastmqid,lastupdatetime,createtime)
										   values(@consumerclientid,@partitionindex,@partitionid,@lastconsumertempid,@lastmqid,@lastupdatetime,@createtime)", Par);
            return rev == 1;

        }

        public virtual bool Edit(DbConn PubConn, tb_consumer_partition_model model)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>()
            {
                    
					//�����߿ͻ���ID
					new ProcedureParameter("@consumerclientid",    model.consumerclientid),
					//
					new ProcedureParameter("@partitionindex",    model.partitionindex),
					//������ID
					new ProcedureParameter("@partitionid",    model.partitionid),
					//
					new ProcedureParameter("@lastconsumertempid",    model.lastconsumertempid),
					//������ѵ�MQID
					new ProcedureParameter("@lastmqid",    model.lastmqid),
					//���������ִ��ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@lastupdatetime",    model.lastupdatetime),
					//�����߷�������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@createtime",    model.createtime)
            };
			Par.Add(new ProcedureParameter("@id",  model.id));

            int rev = PubConn.ExecuteSql("update tb_consumer_partition set consumerclientid=@consumerclientid,partitionindex=@partitionindex,partitionid=@partitionid,lastconsumertempid=@lastconsumertempid,lastmqid=@lastmqid,lastupdatetime=@lastupdatetime,createtime=@createtime where id=@id", Par);
            return rev == 1;

        }

        public virtual bool Delete(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id",  id));

            string Sql = "delete from tb_consumer_partition where id=@id";
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

        public virtual tb_consumer_partition_model Get(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id", id));
            StringBuilder stringSql = new StringBuilder();
            stringSql.Append(@"select s.* from tb_consumer_partition s WITH(NOLOCK) where s.id=@id");
            DataSet ds = new DataSet();
            PubConn.SqlToDataSet(ds, stringSql.ToString(), Par);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
				return CreateModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }

		public virtual tb_consumer_partition_model CreateModel(DataRow dr)
        {
            var o = new tb_consumer_partition_model();
			
			//
			if(dr.Table.Columns.Contains("id"))
			{
				o.id = dr["id"].Toint();
			}
			//�����߿ͻ���ID
			if(dr.Table.Columns.Contains("consumerclientid"))
			{
				o.consumerclientid = dr["consumerclientid"].Toint();
			}
			//
			if(dr.Table.Columns.Contains("partitionindex"))
			{
				o.partitionindex = dr["partitionindex"].Toint();
			}
			//������ID
			if(dr.Table.Columns.Contains("partitionid"))
			{
				o.partitionid = dr["partitionid"].Toint();
			}
			//
			if(dr.Table.Columns.Contains("lastconsumertempid"))
			{
				o.lastconsumertempid = dr["lastconsumertempid"].Tolong();
			}
			//������ѵ�MQID
			if(dr.Table.Columns.Contains("lastmqid"))
			{
				o.lastmqid = dr["lastmqid"].Tolong();
			}
			//���������ִ��ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
			if(dr.Table.Columns.Contains("lastupdatetime"))
			{
				o.lastupdatetime = dr["lastupdatetime"].ToDateTime();
			}
			//�����߷�������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
			if(dr.Table.Columns.Contains("createtime"))
			{
				o.createtime = dr["createtime"].ToDateTime();
			}
			return o;
        }
    }
}