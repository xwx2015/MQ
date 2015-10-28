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
	public partial class tb_producter_dal
    {
        public virtual bool Add(DbConn PubConn, tb_producter_model model)
        {

            List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
					
					//��������ʱid(������������Ψһ,Guidתlong)
					new ProcedureParameter("@tempid",    model.tempid),
					//����������
					new ProcedureParameter("@productername",    model.productername),
					//ip��ַ
					new ProcedureParameter("@ip",    model.ip),
					//����id
					new ProcedureParameter("@mqpathid",    model.mqpathid),
					//�������������ʱ��
					new ProcedureParameter("@lastheartbeat",    model.lastheartbeat),
					//�����ߴ���ʱ��
					new ProcedureParameter("@createtime",    model.createtime)   
                };
            int rev = PubConn.ExecuteSql(@"insert into tb_producter(tempid,productername,ip,mqpathid,lastheartbeat,createtime)
										   values(@tempid,@productername,@ip,@mqpathid,@lastheartbeat,@createtime)", Par);
            return rev == 1;

        }

        public virtual bool Edit(DbConn PubConn, tb_producter_model model)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>()
            {
                    
					//��������ʱid(������������Ψһ,Guidתlong)
					new ProcedureParameter("@tempid",    model.tempid),
					//����������
					new ProcedureParameter("@productername",    model.productername),
					//ip��ַ
					new ProcedureParameter("@ip",    model.ip),
					//����id
					new ProcedureParameter("@mqpathid",    model.mqpathid),
					//�������������ʱ��
					new ProcedureParameter("@lastheartbeat",    model.lastheartbeat),
					//�����ߴ���ʱ��
					new ProcedureParameter("@createtime",    model.createtime)
            };
			Par.Add(new ProcedureParameter("@id",  model.id));

            int rev = PubConn.ExecuteSql("update tb_producter set tempid=@tempid,productername=@productername,ip=@ip,mqpathid=@mqpathid,lastheartbeat=@lastheartbeat,createtime=@createtime where id=@id", Par);
            return rev == 1;

        }

        public virtual bool Delete(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id",  id));

            string Sql = "delete from tb_producter where id=@id";
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

        public virtual tb_producter_model Get(DbConn PubConn, int id)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@id", id));
            StringBuilder stringSql = new StringBuilder();
            stringSql.Append(@"select s.* from tb_producter s WITH(NOLOCK) where s.id=@id");
            DataSet ds = new DataSet();
            PubConn.SqlToDataSet(ds, stringSql.ToString(), Par);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
				return CreateModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }

		public virtual tb_producter_model CreateModel(DataRow dr)
        {
            var o = new tb_producter_model();
			
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
			//����������
			if(dr.Table.Columns.Contains("productername"))
			{
				o.productername = dr["productername"].Tostring();
			}
			//ip��ַ
			if(dr.Table.Columns.Contains("ip"))
			{
				o.ip = dr["ip"].Tostring();
			}
			//����id
			if(dr.Table.Columns.Contains("mqpathid"))
			{
				o.mqpathid = dr["mqpathid"].Toint();
			}
			//�������������ʱ��
			if(dr.Table.Columns.Contains("lastheartbeat"))
			{
				o.lastheartbeat = dr["lastheartbeat"].ToDateTime();
			}
			//�����ߴ���ʱ��
			if(dr.Table.Columns.Contains("createtime"))
			{
				o.createtime = dr["createtime"].ToDateTime();
			}
			return o;
        }
    }
}