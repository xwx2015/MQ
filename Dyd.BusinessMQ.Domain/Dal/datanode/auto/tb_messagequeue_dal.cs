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
	public partial class tb_messagequeue_dal
    {
        public virtual bool Add(DbConn PubConn, tb_messagequeue_model model)
        {

            List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
					
					//mq�������߶˵Ĵ���ʱ�䣨�����߶�ʱ����ܸ�������ʱ�䲻һ�£�
					new ProcedureParameter("@mqcreatetime",    model.mqcreatetime),
					//sql���ݽڵ㴦�Ĵ���ʱ��
					new ProcedureParameter("@sqlcreatetime",    model.sqlcreatetime),
					//��Ϣ����,0=�ɶ���Ϣ��1=��Ǩ����Ϣ
					new ProcedureParameter("@state",    model.state),
					//��Դ����:0 ��ʾ ��������,1 ��ʾ Ǩ����Ϣ
					new ProcedureParameter("@source",    model.source),
					//��Ϣ�壨��Ϣ����,��json��ʽ�洢��Ϊ���Ķ����ǣ�
					new ProcedureParameter("@message",    model.message)   
                };
            int rev = PubConn.ExecuteSql(@"insert into tb_messagequeue(mqcreatetime,sqlcreatetime,state,source,message)
										   values(@mqcreatetime,@sqlcreatetime,@state,@source,@message)", Par);
            return rev == 1;

        }

       

        public virtual bool Edit(DbConn PubConn, tb_messagequeue_model model)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>()
            {
                    
					//mq�������߶˵Ĵ���ʱ�䣨�����߶�ʱ����ܸ�������ʱ�䲻һ�£�
					new ProcedureParameter("@mqcreatetime",    model.mqcreatetime),
					//sql���ݽڵ㴦�Ĵ���ʱ��
					new ProcedureParameter("@sqlcreatetime",    model.sqlcreatetime),
					//��Ϣ����,0=�ɶ���Ϣ��1=��Ǩ����Ϣ
					new ProcedureParameter("@state",    model.state),
					//��Դ����:0 ��ʾ ��������,1 ��ʾ Ǩ����Ϣ
					new ProcedureParameter("@source",    model.source),
					//��Ϣ�壨��Ϣ����,��json��ʽ�洢��Ϊ���Ķ����ǣ�
					new ProcedureParameter("@message",    model.message)
            };
			Par.Add(new ProcedureParameter("@id",  model.id));

            int rev = PubConn.ExecuteSql("update tb_messagequeue set mqcreatetime=@mqcreatetime,sqlcreatetime=@sqlcreatetime,state=@state,source=@source,message=@message where id=@id", Par);
            return rev == 1;

        }

        public virtual bool Delete(DbConn PubConn, long id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id",  id));

            string Sql = "delete from tb_messagequeue where id=@id";
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

        public virtual tb_messagequeue_model Get(DbConn PubConn, long id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id", id));
            StringBuilder stringSql = new StringBuilder();
            stringSql.Append(@"select s.* from tb_messagequeue s WITH(NOLOCK)  where s.id=@id");
            DataSet ds = new DataSet();
            PubConn.SqlToDataSet(ds, stringSql.ToString(), Par);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
				return CreateModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }

		public virtual tb_messagequeue_model CreateModel(DataRow dr)
        {
            var o = new tb_messagequeue_model();
			
			//��Ϣid��,����1+���ݽڵ���+��������+ʱ�������+����id
			if(dr.Table.Columns.Contains("id"))
			{
				o.id = dr["id"].Tolong();
			}
			//mq�������߶˵Ĵ���ʱ�䣨�����߶�ʱ����ܸ�������ʱ�䲻һ�£�
			if(dr.Table.Columns.Contains("mqcreatetime"))
			{
				o.mqcreatetime = dr["mqcreatetime"].ToDateTime();
			}
			//sql���ݽڵ㴦�Ĵ���ʱ��
			if(dr.Table.Columns.Contains("sqlcreatetime"))
			{
				o.sqlcreatetime = dr["sqlcreatetime"].ToDateTime();
			}
			//��Ϣ����,0=�ɶ���Ϣ��1=��Ǩ����Ϣ
			if(dr.Table.Columns.Contains("state"))
			{
				o.state = dr["state"].ToByte();
			}
			//��Դ����:0 ��ʾ ��������,1 ��ʾ Ǩ����Ϣ
			if(dr.Table.Columns.Contains("source"))
			{
				o.source = dr["source"].ToByte();
			}
			//��Ϣ�壨��Ϣ����,��json��ʽ�洢��Ϊ���Ķ����ǣ�
			if(dr.Table.Columns.Contains("message"))
			{
				o.message = dr["message"].Tostring();
			}
			return o;
        }
    }
}