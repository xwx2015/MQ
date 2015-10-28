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
	public partial class tb_partition_dal
    {
        public virtual bool Add(DbConn PubConn, tb_partition_model model)
        {

            List<ProcedureParameter> Par = new List<ProcedureParameter>()
                {
					
					//�Ƿ���ʹ��
					new ProcedureParameter("@isused",    model.isused),
					//����ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@createtime",    model.createtime)   
                };
            int rev = PubConn.ExecuteSql(@"insert into tb_partition(isused,createtime)
										   values(@isused,@createtime)", Par);
            return rev == 1;

        }

        public virtual bool Edit(DbConn PubConn, tb_partition_model model)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>()
            {
                    
					//�Ƿ���ʹ��
					new ProcedureParameter("@isused",    model.isused),
					//����ʱ��(�Ե�ǰ��ʱ��Ϊ׼)
					new ProcedureParameter("@createtime",    model.createtime)
            };
			Par.Add(new ProcedureParameter("@partitionid",  model.partitionid));

            int rev = PubConn.ExecuteSql("update tb_partition set isused=@isused,createtime=@createtime where partitionid=@partitionid", Par);
            return rev == 1;

        }

        public virtual bool Delete(DbConn PubConn, int partitionid)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@partitionid",  partitionid));

            string Sql = "delete from tb_partition where partitionid=@partitionid";
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

        public virtual tb_partition_model Get(DbConn PubConn, int partitionid)
        {
            List<ProcedureParameter> Par = new List<ProcedureParameter>();
            Par.Add(new ProcedureParameter("@partitionid", partitionid));
            StringBuilder stringSql = new StringBuilder();
            stringSql.Append(@"select s.* from tb_partition s where s.partitionid=@partitionid");
            DataSet ds = new DataSet();
            PubConn.SqlToDataSet(ds, stringSql.ToString(), Par);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
				return CreateModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }

		public virtual tb_partition_model CreateModel(DataRow dr)
        {
            var o = new tb_partition_model();
			
			//����id��,����1+���ݽڵ���+��������
			if(dr.Table.Columns.Contains("partitionid"))
			{
				o.partitionid = dr["partitionid"].Toint();
			}
			//�Ƿ���ʹ��
			if(dr.Table.Columns.Contains("isused"))
			{
				o.isused = dr["isused"].Tobool();
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