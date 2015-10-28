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
	public partial class tb_mqpath_dal
    {
        public virtual bool Add(DbConn PubConn, tb_mqpath_model model)
        {

            List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
					
					//mq·��
					new ProcedureParameter("@mqpath",    model.mqpath),
					//��·����mq,����������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@lastupdatetime",    model.lastupdatetime),
					//mq����ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@createtime",    model.createtime)   
                };
            int rev = PubConn.ExecuteSql(@"insert into tb_mqpath(mqpath,lastupdatetime,createtime)
										   values(@mqpath,@lastupdatetime,@createtime)", Par);
            return rev == 1;

        }

        public virtual bool Edit(DbConn PubConn, tb_mqpath_model model)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>()
            {
                    
					//mq·��
					new ProcedureParameter("@mqpath",    model.mqpath),
					//��·����mq,����������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@lastupdatetime",    model.lastupdatetime),
					//mq����ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@createtime",    model.createtime)
            };
			Par.Add(new ProcedureParameter("@id",  model.id));

            int rev = PubConn.ExecuteSql("update tb_mqpath set mqpath=@mqpath,lastupdatetime=@lastupdatetime,createtime=@createtime where id=@id", Par);
            return rev == 1;

        }

        public virtual bool Delete(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id",  id));

            string Sql = "delete from tb_mqpath where id=@id";
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

        public virtual tb_mqpath_model Get(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id", id));
            StringBuilder stringSql = new StringBuilder();
            stringSql.Append(@"select s.* from tb_mqpath s WITH(NOLOCK) where s.id=@id");
            DataSet ds = new DataSet();
            PubConn.SqlToDataSet(ds, stringSql.ToString(), Par);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
				return CreateModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }

		public virtual tb_mqpath_model CreateModel(DataRow dr)
        {
            var o = new tb_mqpath_model();
			
			//
			if(dr.Table.Columns.Contains("id"))
			{
				o.id = dr["id"].Toint();
			}
			//mq·��
			if(dr.Table.Columns.Contains("mqpath"))
			{
				o.mqpath = dr["mqpath"].Tostring();
			}
			//��·����mq,����������ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
			if(dr.Table.Columns.Contains("lastupdatetime"))
			{
				o.lastupdatetime = dr["lastupdatetime"].ToDateTime();
			}
			//mq����ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
			if(dr.Table.Columns.Contains("createtime"))
			{
				o.createtime = dr["createtime"].ToDateTime();
			}
			return o;
        }
    }
}