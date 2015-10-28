using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Data;
using System.Text;
using XXF.Extensions;
using XXF.Db;
using XXF.BaseService.MessageQuque.Model;
using XXF.ProjectTool;
using XXF.BaseService.MessageQuque.BusinessMQ.SystemRuntime;

namespace XXF.BaseService.MessageQuque.Dal
{
    /*�����Զ����ɹ����Զ�����,��Ҫ������д�Լ��Ĵ��룬����ᱻ�Զ�����Ŷ - ����*/
    public partial class tb_messagequeue_dal
    {
        public string TableName { get; set; }

        public long GetMaxId(DbConn PubConn)
        {
            return SqlHelper.Visit((ps) =>
            {
                string cmd = string.Format("select max(id) from {0} s WITH(NOLOCK)", TableName);
                var o = PubConn.ExecuteScalar(cmd, null);
                if (o == null || o is DBNull)
                    return -1;
                else
                    return Convert.ToInt64(o);
            });

        }

        public List<tb_messagequeue_model> GetMessages(DbConn PubConn, long lastmaxmessageid, int topcount)
        {
            return SqlHelper.Visit((ps) =>
            {
                List<tb_messagequeue_model> rs = new List<tb_messagequeue_model>();
                ps.Add("@lastmaxmessageid", lastmaxmessageid);
                string cmd = string.Format("select top {1} * from {0} s {2} where id>@lastmaxmessageid order by id asc", TableName, topcount, (SystemParamConfig.Consumer_ReadMessage_WithNolock==true?"with (nolock)":""));
                DataSet ds = new DataSet();
                PubConn.SqlToDataSet(ds, cmd, ps.ToParameters());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var o = CreateModel(dr);
                        rs.Add(o);
                    }
                }
                return rs;
            });

        }

        public virtual bool Add2(DbConn PubConn, tb_messagequeue_model model)
        {

            List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
					
					//mq�������߶˵Ĵ���ʱ�䣨�����߶�ʱ����ܸ�������ʱ�䲻һ�£�
					new ProcedureParameter("@mqcreatetime",    model.mqcreatetime),
					//��Ϣ����,0=�ɶ���Ϣ��1=��Ǩ����Ϣ
					new ProcedureParameter("@state",    model.state),
					//��Դ����:0 ��ʾ ��������,1 ��ʾ Ǩ����Ϣ
					new ProcedureParameter("@source",    model.source),
					//��Ϣ�壨��Ϣ����,��json��ʽ�洢��Ϊ���Ķ����ǣ�
					new ProcedureParameter("@message",    model.message),
                    //sql���ݽڵ㴦�Ĵ���ʱ��(�Թ�������ʱ��Ϊ׼)
					new ProcedureParameter("@sqlcreatetime",    model.sqlcreatetime)   
                };
            int rev = PubConn.ExecuteSql(string.Format(@"insert into {0}(mqcreatetime,sqlcreatetime,state,source,message) values(@mqcreatetime,@sqlcreatetime,@state,@source,@message)", TableName), Par);
            return rev == 1;

        }

       

        public virtual tb_messagequeue_model CreateModel(DataRow dr)
        {
            var o = new tb_messagequeue_model();

            //��Ϣid��,����1+���ݽڵ���+��������+ʱ�������+����id
            if (dr.Table.Columns.Contains("id"))
            {
                o.id = dr["id"].Tolong();
            }
            //mq�������߶˵Ĵ���ʱ�䣨�����߶�ʱ����ܸ�������ʱ�䲻һ�£�
            if (dr.Table.Columns.Contains("mqcreatetime"))
            {
                o.mqcreatetime = dr["mqcreatetime"].ToDateTime();
            }
            //sql���ݽڵ㴦�Ĵ���ʱ��
            if (dr.Table.Columns.Contains("sqlcreatetime"))
            {
                o.sqlcreatetime = dr["sqlcreatetime"].ToDateTime();
            }
            //��Ϣ����,0=�ɶ���Ϣ��1=��Ǩ����Ϣ
            if (dr.Table.Columns.Contains("state"))
            {
                o.state = dr["state"].ToByte();
            }
            //��Դ����:0 ��ʾ ��������,1 ��ʾ Ǩ����Ϣ
            if (dr.Table.Columns.Contains("source"))
            {
                o.source = dr["source"].ToByte();
            }
            //��Ϣ�壨��Ϣ����,��json��ʽ�洢��Ϊ���Ķ����ǣ�
            if (dr.Table.Columns.Contains("message"))
            {
                o.message = dr["message"].Tostring();
            }
            return o;
        }
    }
}