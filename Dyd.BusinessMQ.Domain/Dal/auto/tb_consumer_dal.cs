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
	public partial class tb_consumer_dal
    {
        public virtual bool Add(DbConn PubConn, tb_consumer_model model)
        {

            List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
					
					//��������ʱid(������������Ψһ,Guidתlong)
					new ProcedureParameter("@tempid",    model.tempid),
					//������clinet��id
					new ProcedureParameter("@consumerclientid",    model.consumerclientid),
					//֧�ֵķ���˳���(֧�ֶ��˳���)
					new ProcedureParameter("@partitionindexs",    model.partitionindexs),
					//�ͻ�������
					new ProcedureParameter("@clientname",    model.clientname),
					//�������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@lastheartbeat",    model.lastheartbeat),
					//��һ�θ���ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@lastupdatetime",    model.lastupdatetime),
					//�ͻ��˴���ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@createtime",    model.createtime)   
                };
            int rev = PubConn.ExecuteSql(@"insert into tb_consumer(tempid,consumerclientid,partitionindexs,clientname,lastheartbeat,lastupdatetime,createtime)
										   values(@tempid,@consumerclientid,@partitionindexs,@clientname,@lastheartbeat,@lastupdatetime,@createtime)", Par);
            return rev == 1;

        }

        public virtual bool Edit(DbConn PubConn, tb_consumer_model model)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>()
            {
                    
					//��������ʱid(������������Ψһ,Guidתlong)
					new ProcedureParameter("@tempid",    model.tempid),
					//������clinet��id
					new ProcedureParameter("@consumerclientid",    model.consumerclientid),
					//֧�ֵķ���˳���(֧�ֶ��˳���)
					new ProcedureParameter("@partitionindexs",    model.partitionindexs),
					//�ͻ�������
					new ProcedureParameter("@clientname",    model.clientname),
					//�������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@lastheartbeat",    model.lastheartbeat),
					//��һ�θ���ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@lastupdatetime",    model.lastupdatetime),
					//�ͻ��˴���ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@createtime",    model.createtime)
            };
			Par.Add(new ProcedureParameter("@id",  model.id));

            int rev = PubConn.ExecuteSql("update tb_consumer set tempid=@tempid,consumerclientid=@consumerclientid,partitionindexs=@partitionindexs,clientname=@clientname,lastheartbeat=@lastheartbeat,lastupdatetime=@lastupdatetime,createtime=@createtime where id=@id", Par);
            return rev == 1;

        }

        public virtual bool Delete(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id",  id));

            string Sql = "delete from tb_consumer where id=@id";
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

        public virtual tb_consumer_model Get(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id", id));
            StringBuilder stringSql = new StringBuilder();
            stringSql.Append(@"select s.* from tb_consumer s where s.id=@id");
            DataSet ds = new DataSet();
            PubConn.SqlToDataSet(ds, stringSql.ToString(), Par);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
				return CreateModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }

		public virtual tb_consumer_model CreateModel(DataRow dr)
        {
            var o = new tb_consumer_model();
			
			//
			if(dr.Table.Columns.Contains("id"))
			{
				o.id = dr["id"].Toint();
			}
			//��������ʱid(������������Ψһ,Guidתlong)
			if(dr.Table.Columns.Contains("tempid"))
			{
				o.tempid = dr["tempid"].Tolong();
			}
			//������clinet��id
			if(dr.Table.Columns.Contains("consumerclientid"))
			{
				o.consumerclientid = dr["consumerclientid"].Toint();
			}
			//֧�ֵķ���˳���(֧�ֶ��˳���)
			if(dr.Table.Columns.Contains("partitionindexs"))
			{
				o.partitionindexs = dr["partitionindexs"].Tostring();
			}
			//�ͻ�������
			if(dr.Table.Columns.Contains("clientname"))
			{
				o.clientname = dr["clientname"].Tostring();
			}
			//�������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
			if(dr.Table.Columns.Contains("lastheartbeat"))
			{
				o.lastheartbeat = dr["lastheartbeat"].ToDateTime();
			}
			//��һ�θ���ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
			if(dr.Table.Columns.Contains("lastupdatetime"))
			{
				o.lastupdatetime = dr["lastupdatetime"].ToDateTime();
			}
			//�ͻ��˴���ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
			if(dr.Table.Columns.Contains("createtime"))
			{
				o.createtime = dr["createtime"].ToDateTime();
			}
			return o;
        }
    }
}