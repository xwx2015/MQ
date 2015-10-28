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
	public partial class tb_partition_messagequeue_report_dal
    {
        public virtual bool Add(DbConn PubConn, tb_partition_messagequeue_report_model model)
        {

            List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
					
					//�������
					new ProcedureParameter("@partitionid",    model.partitionid),
					//����
					new ProcedureParameter("@day",    model.day),
					//���������Ϣid
					new ProcedureParameter("@mqmaxid",    model.mqmaxid),
					//mq��С��Ϣid
					new ProcedureParameter("@mqminid",    model.mqminid),
					//��Ϣ����
					new ProcedureParameter("@mqcount",    model.mqcount),
					//��ǰ����ɨ��������ʱ��
					new ProcedureParameter("@lastupdatetime",    model.lastupdatetime),
					//��ǰ����ɨ�贴��ʱ��
					new ProcedureParameter("@createtime",    model.createtime)   
                };
            int rev = PubConn.ExecuteSql(@"insert into tb_partition_messagequeue_report(partitionid,day,mqmaxid,mqminid,mqcount,lastupdatetime,createtime)
										   values(@partitionid,@day,@mqmaxid,@mqminid,@mqcount,@lastupdatetime,@createtime)", Par);
            return rev == 1;

        }

        public virtual bool Edit(DbConn PubConn, tb_partition_messagequeue_report_model model)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>()
            {
                    
					//�������
					new ProcedureParameter("@partitionid",    model.partitionid),
					//����
					new ProcedureParameter("@day",    model.day),
					//���������Ϣid
					new ProcedureParameter("@mqmaxid",    model.mqmaxid),
					//mq��С��Ϣid
					new ProcedureParameter("@mqminid",    model.mqminid),
					//��Ϣ����
					new ProcedureParameter("@mqcount",    model.mqcount),
					//��ǰ����ɨ��������ʱ��
					new ProcedureParameter("@lastupdatetime",    model.lastupdatetime),
					//��ǰ����ɨ�贴��ʱ��
					new ProcedureParameter("@createtime",    model.createtime)
            };
			Par.Add(new ProcedureParameter("@id",  model.id));

            int rev = PubConn.ExecuteSql("update tb_partition_messagequeue_report set partitionid=@partitionid,day=@day,mqmaxid=@mqmaxid,mqminid=@mqminid,mqcount=@mqcount,lastupdatetime=@lastupdatetime,createtime=@createtime where id=@id", Par);
            return rev == 1;

        }

        public virtual bool Delete(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id",  id));

            string Sql = "delete from tb_partition_messagequeue_report where id=@id";
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

        public virtual tb_partition_messagequeue_report_model Get(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id", id));
            StringBuilder stringSql = new StringBuilder();
            stringSql.Append(@"select s.* from tb_partition_messagequeue_report s WITH(NOLOCK) where s.id=@id");
            DataSet ds = new DataSet();
            PubConn.SqlToDataSet(ds, stringSql.ToString(), Par);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
				return CreateModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }

		public virtual tb_partition_messagequeue_report_model CreateModel(DataRow dr)
        {
            var o = new tb_partition_messagequeue_report_model();
			
			//
			if(dr.Table.Columns.Contains("id"))
			{
				o.id = dr["id"].Toint();
			}
			//�������
			if(dr.Table.Columns.Contains("partitionid"))
			{
				o.partitionid = dr["partitionid"].Toint();
			}
			//����
			if(dr.Table.Columns.Contains("day"))
			{
				o.day = dr["day"].ToDateTime();
			}
			//���������Ϣid
			if(dr.Table.Columns.Contains("mqmaxid"))
			{
				o.mqmaxid = dr["mqmaxid"].Tolong();
			}
			//mq��С��Ϣid
			if(dr.Table.Columns.Contains("mqminid"))
			{
				o.mqminid = dr["mqminid"].Tolong();
			}
			//��Ϣ����
			if(dr.Table.Columns.Contains("mqcount"))
			{
				o.mqcount = dr["mqcount"].Toint();
			}
			//��ǰ����ɨ��������ʱ��
			if(dr.Table.Columns.Contains("lastupdatetime"))
			{
				o.lastupdatetime = dr["lastupdatetime"].ToDateTime();
			}
			//��ǰ����ɨ�贴��ʱ��
			if(dr.Table.Columns.Contains("createtime"))
			{
				o.createtime = dr["createtime"].ToDateTime();
			}
			return o;
        }
    }
}